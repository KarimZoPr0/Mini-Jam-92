using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager1 : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager1 instance;

    public bool DontDestoyOnLoad;

    string muteSoundName;
    bool muteSound;
    bool canPlayNext;
    string playNextName;
    bool playOnce;
    float newMaxVolume;

    AudioHighPassFilter highPassFilter;
    AudioLowPassFilter lowPassFilter;

    void Awake()
    {
        // If needed, saves the audio manager on awake
        if (DontDestoyOnLoad)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }

        highPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
        highPassFilter.cutoffFrequency = 130;
        highPassFilter.highpassResonanceQ = 4;
        lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 800;
        lowPassFilter.lowpassResonanceQ = 4;

        highPassFilter.enabled = false;
        lowPassFilter.enabled = false;
    }

    private void Start()
    {
        Reference.audio = this;
        foreach(Sound s in sounds)
        {
            if (s.playOnAwake)
            {
                Play(s.name);
                break;
            }
        }

        
    }

    private void Update()
    {
        if(ActiveSound() == null)
        {
            muteSound = false;
            muteSoundName = null;
        }

        if (muteSound && muteSoundName != null)
        {
            if(playNextName != muteSoundName)
            {
                AudioSource[] audios = GetComponents<AudioSource>();
                canPlayNext = false;
                for (int i = 0; i < audios.Length; i++)
                {
                    if (audios[i].name == muteSoundName)
                    {
                        if (audios[i].volume > 0)
                        {
                            audios[i].volume -= Time.deltaTime * 0.25f;
                            Debug.Log("Muting");
                        }
                        else
                        {
                            Debug.Log("Muted");
                            muteSound = false;
                            muteSoundName = null;
                            audios[i].Stop();
                            Play(playNextName);
                        }
                    }
                }
            }
          
        }
        else
        {
            if (playNextName == muteSoundName && playNextName != null)
            {
                Debug.Log("Muted");
                muteSound = false;
                muteSoundName = null;
                Play(playNextName);
            }
            else
            {
                muteSound = false;
                muteSoundName = null;
                //Play(playNextName);
            }
        }

        if (ActiveSound().volume < newMaxVolume && !muteSound)
        {
            ActiveSound().volume += Time.deltaTime*0.25f;
        }
    }
    // Plays the sound
    public void Play (string name)
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        if(!isPlaying(name)){
            for(int i=0; i<audios.Length; i++)
            {
                if (audios[i].isPlaying)
                {
                    if(muteSoundName != audios[i].name)
                    {
                        Stop(audios[i].name);
                        canPlayNext = false;
                        playNextName = name;
                        playOnce = true;
                        return;
                    }
                    muteSound = false;
                    muteSoundName = null;
                    audios[i].Play();
                    playNextName = audios[i].name;
                    ActiveSound().volume = 0;
                    Sound s = Array.Find(sounds, sound => sound.name == audios[i].name);
                    newMaxVolume = s.volume;
                    return;
                }
            }
        }
        
        if (!isPlaying(name))
        {
            Debug.Log("Play new");
            muteSound = false;
            muteSoundName = null;
            playNextName = name;

            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.mute = false;
            s.source.Play();
            ActiveSound().volume = 0;
            newMaxVolume = s.volume;
        }
    }

    // Stops the sound
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        muteSound = true;
        muteSoundName = name;
    }

    // Returns true if the called sound is playing
    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            return true;
        }
        return false;
    }

    // Sound playing at the moment 
    public AudioSource ActiveSound()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        for (int i = 0; i < audios.Length; i++)
        {
            if (audios[i].isPlaying)
            {
                return audios[i];
            }
        }
        return null;
    }
}
