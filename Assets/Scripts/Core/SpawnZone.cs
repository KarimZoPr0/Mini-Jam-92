using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VFX;

namespace MiniJam.Core
{
    public class SpawnZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool inRange;
        public void OnPointerEnter(PointerEventData eventData)
        {
            inRange = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            inRange = false;
        }
    }
}
