using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public int menuScene = 0;
    public int levelsScene = 1;
    public int aboutScene = 2;

    private void Update()
    {
        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            LoadLevels();
        }
   
    }

    public void LoadLevels()
    {
        print("load");
        Reference.transitor.LoadScene(levelsScene);
    }
}
