using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJam
{
    public class TimeManager : MonoBehaviour
    {
        public float slowdownFactor = 0.05f;
        public float slowdownLenght = 2f;


        private void Update()
        {
            Time.timeScale += (1f / slowdownLenght) * Time.unscaledDeltaTime;
            Time.timeScale =  Mathf.Clamp(Time.timeScale, 0f, 1f);
        }

        public void DoSlowMotion()
        {
            Time.timeScale      = slowdownFactor;
            Time.fixedDeltaTime = Time.deltaTime * 0.02f;
        }
    }
}
