
using UnityEngine;

[System.Serializable]
public class Audio {

    public bool loop;
    public string name;
    [Range(0,1)]
    public float Volume;
    [Range(0, 1)]
    public float Pitch;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;

}

