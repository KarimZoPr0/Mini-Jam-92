using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniJam.Control;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniJam.Core
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private Sprite        _sprite;
        [SerializeField] private SoundsManager sounds;
        [SerializeField] private GameObject    postProcessing;
        [SerializeField] private int           level;

        private bool isAlive = true;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Liquid"))
            {
                Reference.transitor.LoadScene(level);
                GetComponent<SpriteRenderer>().sprite = _sprite;

                if (isAlive)
                    sounds.Play("Hit");
                Invoke(nameof(Die), .6f);
            }
        }

        private void Die()
        {
            isAlive = false;
            CameraController.ShakeCamera(0.15f, 1f);
            postProcessing.SetActive(true);
            sounds.Play("Die");

            Invoke(nameof(LoadLevel), 1.4f);
        }

        private void LoadLevel()
        {
            Reference.transitor.LoadScene(level);
        }
    }

}
