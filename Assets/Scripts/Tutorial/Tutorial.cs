using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using MiniJam.Core;
using UnityEngine;

namespace MiniJam
{
    public class Tutorial : MonoBehaviour
    {
        public int        currentScene;
        public int        sceneToLoad;
        public Dragger    dragger;
        public Spawner    spawner;

        [SerializeField] private int spawnTutLimit = 3;
        [SerializeField] private int dragTutLimit  = 1;

        private void Start()
        {
	        if (spawner != null)
	        {
		        spawner.spawnLimit = spawnTutLimit;
		        spawner.UpdateText();
	        }

	        if (dragger != null)
	        { 
		        dragger.dragLimit = dragTutLimit;
		        dragger.UpdateText();
	        }
        }

        private void Update()
        {
	        if(currentScene == 1)
	        {
		        if (spawner == null) return;
		        if(spawner.spawnClickCount == spawnTutLimit -1)
			        Invoke(nameof(LoadLevel), 1.5f);
	        }
	        if(currentScene == 2)
	        {
		        if (dragger == null) return;
		        if(dragger.dragCount == dragTutLimit) 
			        Invoke(nameof(LoadLevel), 1.5f);
	        }

	        if (currentScene == 3)
	        {
		        Invoke(nameof(LoadLevel), 4f);
	        }
        }

        private void LoadLevel()
        {
	        Reference.transitor.LoadScene(sceneToLoad);
        }
    }
}
