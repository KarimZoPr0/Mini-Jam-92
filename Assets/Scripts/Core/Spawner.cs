using MiniJam.Control;
using TMPro;
using UnityEngine;

namespace MiniJam.Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject      prefab;
        private const            int             SpawnLimit = 3;
        private                  int             _spawnAmount;
        
        [SerializeField] private TextMeshProUGUI healthAmount;
        [SerializeField] private SoundsManager   soundsManager;
        private void Start()
        {
            healthAmount.text = SpawnLimit.ToString();
        }
        
        public void Spawn(Vector3 position) => Instantiate(prefab).transform.position = position;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && _spawnAmount < SpawnLimit)
            {
                
                Vector3 worldPoint =
                    Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

                Vector3 adjust2 = new Vector3(worldPoint.x, worldPoint.y, prefab.transform.position.z);

                Spawn(adjust2);
                CameraController.ShakeCamera(0.5f, 0.25f);


                _spawnAmount++;
                soundsManager.Play("WaterImpact");
                if(SpawnLimit - _spawnAmount <= 0) 
                    Reference.transitor.ReloadScene();
                
                healthAmount.text = (SpawnLimit - _spawnAmount).ToString();

            }
        }
        

    }
}
