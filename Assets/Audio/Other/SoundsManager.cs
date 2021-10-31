using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundsManager : MonoBehaviour
{
    private Dictionary<string, Sound> soundsDic = new Dictionary<string, Sound>();
    public  Sound[]                   sounds;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (var sound in sounds)
            soundsDic.Add(sound.name, sound);
        
        foreach (var s in soundsDic.Values)
        {
            s.source             = gameObject.AddComponent<AudioSource>();
            s.source.clip        = s.clip;
            s.source.volume      = s.volume;
            s.source.pitch       = s.pitch;
            s.source.loop        = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
        
    }
    
    public void Play(string name)
    {
       if(soundsDic.ContainsKey(name))
           soundsDic[name].source.Play();
    }
}
