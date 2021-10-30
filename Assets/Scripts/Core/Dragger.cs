using System;
using MiniJam.Control;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MiniJam.Core
{
   public enum Cursor
    {
        Drag,
        Illegal
    }
    public class Dragger : MonoBehaviour
    {
        [SerializeField] private Cursor cursor;

        private bool _canDrag = true;

        private bool isDragging = false;
        private void OnMouseDrag()
        {
            if(!_canDrag) return;
            isDragging         = true;
            transform.position = GetMousePos();
            
        }

        private void OnMouseUp() => Reference.ui.crosshair.ChangeCrosshair("Select");

        private void OnMouseDown() => Reference.ui.crosshair.ChangeCrosshair("Drag");

        private void OnMouseEnter()
        {
            if (cursor == Cursor.Drag) return;
            var crossHair = cursor == Cursor.Illegal ? "Illegal" : "Select";
            Reference.ui.crosshair.ChangeCrosshair(crossHair);
        }

        private void OnMouseExit()
        {
            if (cursor == Cursor.Drag) return;
            Reference.ui.crosshair.ChangeCrosshair("Select");
        }

        Vector3 GetMousePos()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }
        
    }
}
