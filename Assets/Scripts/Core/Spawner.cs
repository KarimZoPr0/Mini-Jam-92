using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJam
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        private const int SpawnLimit = 3;
        private int _spawnAmount;

        public void Spawn(Vector3 position)
        {
            Instantiate(prefab).transform.position = position;
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && _spawnAmount <= SpawnLimit)
            {
                
                Vector3 worldPoint =
                    Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

                Vector3 adjust2 = new Vector3(worldPoint.x, worldPoint.y, prefab.transform.position.z);

                Spawn(adjust2);

                _spawnAmount++;
            }
        }
    }
}
