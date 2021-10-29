using System;
using MiniJam.Control;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MiniJam.Core
{
    public class Dragger : MonoBehaviour
    {
        private void OnMouseDrag()
        {
            transform.position = GetMousePos();
        }

        Vector3 GetMousePos()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }
        
    }
}
