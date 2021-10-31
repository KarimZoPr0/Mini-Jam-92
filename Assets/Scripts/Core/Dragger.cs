using System;
using MiniJam.Control;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

namespace MiniJam.Core
{
   public enum Cursor
    {
        Drag,
        Illegal
    }
    public class Dragger : MonoBehaviour
    {
        [SerializeField] private Cursor          cursor;
        [SerializeField] private SoundsManager   sounds;
        public  int             dragLimit = 2;
        [SerializeField] private TextMeshProUGUI dragAmountTxt;
        [SerializeField] private Tilemap         tilemap;
        
        private Vector3 lastPos;
        private Vector3 currentPos;
        public  int     dragCount;
        

        private void Start()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            dragAmountTxt.text = dragLimit.ToString();
        }

        private void OnMouseDrag()
        {
            if (dragCount >= dragLimit) return;

            transform.position = GetMousePos();
        }

        private void OnMouseUp()
        {
            if(dragCount >= dragLimit) return;
            
            dragCount++;
            dragAmountTxt.text = (dragLimit - dragCount).ToString();

            Reference.ui.crosshair.ChangeCrosshair("Select");
            sounds.Play("WaterImpact");
            //sounds.Play("MouseUp");
        }

        private void OnMouseDown()
        {
            if(dragCount >= dragLimit) return;
            Reference.ui.crosshair.ChangeCrosshair("Drag");
           // sounds.Play("MouseDown");
        }

        private void OnMouseEnter()
        {
            if (dragCount >= dragLimit)
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
