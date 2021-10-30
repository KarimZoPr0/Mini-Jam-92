using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace MiniJam
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [SerializeField] private float    x;
        [SerializeField] private float    y;

        private void Update() => image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.deltaTime, image.uvRect.size);
    }
}
