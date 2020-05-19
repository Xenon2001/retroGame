using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public SoundLibrary[] sounds;

    public static SoundManager instance;

    public AudioMixerGroup masterMixer;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        if(instance!=this)
        { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
        

        foreach (SoundLibrary s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.soundClip;
            s.source.volume = s.soundVolume;
            s.source.loop = s.toLoop;

            s.source.outputAudioMixerGroup = masterMixer;
        }
    }

    public void PlaySound(string name)
    {
        SoundLibrary s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


    //stops all sounds
    public void StopSound()
    {
        foreach (SoundLibrary s in sounds)
            s.source.Stop();
    }

    //returns whether or not the specified sound is playing
    public bool SoundIsPlaying(string name)
    {
        SoundLibrary s = Array.Find(sounds, sound => sound.name == name); 
        return s.source.isPlaying;
    }

}
