using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneMusic : MonoBehaviour
{
    public string SceneMusic;
    private void Start()
    {
        FindObjectOfType<AudioManager1>().Play(SceneMusic);
    }
}
