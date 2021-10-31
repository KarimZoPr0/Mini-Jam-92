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

        public bool isAlive = true;


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isAlive) return;
            if (other.gameObject.CompareTag("Liquid"))
            {
                StartCoroutine(Die());

            }
        }

        IEnumerator Die()
        {
            isAlive                               = false;
            GetComponent<SpriteRenderer>().sprite = _sprite;
            
            postProcessing.SetActive(true);
            sounds.Play("Die");
            CameraController.ShakeCamera(0.5f, .25f);
            yield return new WaitForSeconds(0.6f);
            Reference.transitor.LoadScene(level);
        }
        
    }

}
