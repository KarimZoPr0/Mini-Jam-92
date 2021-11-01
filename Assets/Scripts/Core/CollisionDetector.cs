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
        [SerializeField] private GameObject    defaultPostProcessing;
        [SerializeField] private GameObject    deathPostProcessing;
        [SerializeField] private int           level;

        public CharacterManager cm;

        public bool isAlive = true;
        public int  totalAlive;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isAlive) return;
            if (other.gameObject.CompareTag("Liquid"))
            {
                sounds.Play("Die");
                StartCoroutine(Die());

            }
        }

        IEnumerator Die()
        {
            cm.deadCharacters++;
            isAlive                               =  false;
            GetComponent<SpriteRenderer>().sprite =  _sprite;
            
            CameraController.ShakeCamera(0.5f, .25f);

            if (totalAlive - cm.deadCharacters != 0) yield break;
            defaultPostProcessing.SetActive(false);
            deathPostProcessing.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            Reference.transitor.Fade();
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(level);
        }
        
    }

}
