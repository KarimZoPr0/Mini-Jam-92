using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJam.Core
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Liquid"))
            {
                
            }
        }
    }
}
