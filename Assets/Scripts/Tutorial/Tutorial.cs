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
        public int     currentScene;
        public int     sceneToLoad;
        public Dragger dragger;
        public Spawner spawner;

        [SerializeField] private int spawnTutLimit = 3;
        [SerializeField] private int dragTutLimit = 3;
        
        
        private void Start()
        {
	        
	        spawner.spawnLimit = spawnTutLimit;

	        if (dragger != null)
	        {
		        dragger.dragLimit = dragTutLimit;
	        }
	       
        }

        private void Update()
        {
	        if(currentScene == 1)
	        {
		        if(spawner.spawnClickCount == spawnTutLimit)
			        Invoke(nameof(LoadLevel), 1.5f);
	        }
	        if(currentScene == 2)
	        {
		        if (dragger == null) return;
		        if(dragger.dragCount == dragTutLimit) 
			        Invoke(nameof(LoadLevel), 1.5f);
	        }

        }

        private void LoadLevel()
        {
	        Reference.transitor.LoadScene(sceneToLoad);
        }
    }
}
