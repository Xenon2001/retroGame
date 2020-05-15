using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundLibrary
{
    public string name;
    public AudioClip soundClip;
    public AudioSource source;

    [Range(-60f, 0f)]
    public float soundVolume;

    public bool toLoop;
}

