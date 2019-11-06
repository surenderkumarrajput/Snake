using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour

{
    public Audio[] sound;
    public static AudioManager instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        foreach (Audio a in sound)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.Volume;
            a.source.pitch = a.Pitch;
            a.source.loop = a.loop;
        }
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Play("Theme");
    }
    public void Play(String name)
    {
        Audio s = Array.Find(sound, sound =>sound.name==name);
        s.source.Play();
    }
}

