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
        
        [HideInInspector] public int  spawnClickCount; 
        public bool isTutorial = false;
        private void Start()
        {
            if(healthAmount != null) 
                healthAmount.text = spawnLimit.ToString();
        }
        
        public void Spawn(Vector3 position) => Instantiate(prefab).transform.position = position;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && spawnClickCount < spawnLimit)
            {
                
                Vector3 worldPoint =
                    Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
                
                Vector3 adjust2 = new Vector3(worldPoint.x, worldPoint.y, prefab.transform.position.z);
                Spawn(adjust2);

                CameraController.ShakeCamera(0.15f, 0.15f);

                spawnClickCount++;
                soundsManager.Play("WaterImpact");

                if(healthAmount == null || spawnLimit <= 0) return;
                healthAmount.text = (spawnLimit - spawnClickCount).ToString();
                
                if (isTutorial) return; 
                
                if(spawnLimit - spawnClickCount <= 0) 
                    Reference.transitor.ReloadScene();
                
               

            }
        }
        

    }
}
