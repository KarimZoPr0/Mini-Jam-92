using System;
using MiniJam.Control;
using TMPro;
using UnityEngine;

namespace MiniJam.Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject      prefab;
        public                   int             spawnLimit = 3;
        [SerializeField] private TextMeshProUGUI healthAmount;
        [SerializeField] private SoundsManager   soundsManager;
        [SerializeField] private GameObject      postProcessing;
        [SerializeField] private SpawnZone       spawnZone;
        
        [HideInInspector] public int  spawnClickCount; 
        public bool isTutorial = false;
        private void Start()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            if (healthAmount != null)
                healthAmount.text = spawnLimit.ToString();
        }

        public void Spawn(Vector3 position) => Instantiate(prefab).transform.position = position;

        private void Update()
        {
            var canSpawn = spawnClickCount < spawnLimit && spawnZone.inRange;
            
            if(Input.GetKeyDown(KeyCode.Mouse1) && canSpawn)
            {
                Vector3 worldPoint =
                    Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            
                Vector3 adjust2 = new Vector3(worldPoint.x, worldPoint.y, prefab.transform.position.z);
              
                Spawn(adjust2);

                CameraController.ShakeCamera(0.15f, 0.15f);

                spawnClickCount++;
                soundsManager.Play("WaterImpact");

                // int 1 is to make sure he doesn't die
                healthAmount.text = (spawnLimit - spawnClickCount).ToString();
                if(healthAmount == null || (spawnLimit - spawnClickCount) <= 1) return;
                
                
                if(spawnLimit - spawnClickCount <= 0) 
                    Reference.transitor.ReloadScene();

            }
        }
        

    }
}
