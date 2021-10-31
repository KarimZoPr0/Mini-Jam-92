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

        [SerializeField] private Sprite _sprite;

        [SerializeField] private SoundsManager sounds;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Liquid"))
            {
                GetComponent<SpriteRenderer>().sprite = _sprite;
                sounds.Play("Hit");
                Invoke(nameof(Die), 1.5f);
            }
        }

        private void Die()
        {
            sounds.Play("Die");
            Reference.transitor.LoadScene(level);
        }

        public async void GoblinSound()
        {
            sounds.Play("Hit");
            sounds.Play("Die");
            Reference.transitor.LoadScene(level);
        }
    }
}
