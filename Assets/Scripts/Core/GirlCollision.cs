using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniJam.Control;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniJam.Core
{
	public class GirlCollision : MonoBehaviour
	{
		[SerializeField] private SoundsManager sounds;
		[SerializeField] private GameObject    defaultPostProcessing;
		[SerializeField] private GameObject    deathPostProcessing;

		private bool isDead = false;
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (isDead) return;
			if (other.gameObject.CompareTag("Liquid"))
			{
				isDead = true;
				sounds.Play("Dieg");
				StartCoroutine(Die());

			}
		}

		IEnumerator Die()
		{
			CameraController.ShakeCamera(0.5f, .25f);
			defaultPostProcessing.SetActive(false);
			deathPostProcessing.SetActive(true);
			yield return new WaitForSeconds(0.7f);
			Reference.transitor.ReloadScene();
		}
        
	}

}