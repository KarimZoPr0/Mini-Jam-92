using System;
using MiniJam.Control;
using TMPro;
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
        [SerializeField] private Cursor        cursor;
        [SerializeField] private SoundsManager sounds;
        [SerializeField] private int           dragMax = 2;
        [SerializeField] private int           dragCount;

        [SerializeField] private TextMeshProUGUI dragAmountTxt;


        private void Start()
        {
            dragAmountTxt.text = dragMax.ToString();
        }

        private void OnMouseDrag()
        {
            if (dragCount >= dragMax) return;

            transform.position = GetMousePos();
        }

        private void OnMouseUp()
        {
            if(dragCount >= dragMax) return;
            
            dragCount++;
            dragAmountTxt.text = (dragMax - dragCount).ToString();

            Reference.ui.crosshair.ChangeCrosshair("Select");
            sounds.Play("WaterImpact");
            //sounds.Play("MouseUp");
        }

        private void OnMouseDown()
        {
            if(dragCount > dragMax) return;
            Reference.ui.crosshair.ChangeCrosshair("Drag");
           // sounds.Play("MouseDown");
        }

        private void OnMouseEnter()
        {
            if (dragCount >= dragMax)
            {
                cursor = Cursor.Illegal;
            }
            var crossHair = cursor == Cursor.Illegal ? "Illegal" : "Select";

            Reference.ui.crosshair.ChangeCrosshair(crossHair);
        }

        private void OnMouseExit()
        {
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
