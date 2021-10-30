using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniJam.Core
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private int level;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Liquid"))
            {
                Reference.transitor.LoadScene(level);
            }
        }
    }
}
