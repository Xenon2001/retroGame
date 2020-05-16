using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone2 : MonoBehaviour
{

    void Start()
    {
        SoundManager.instance.StopSound();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !SoundManager.instance.SoundIsPlaying("Zone2Music"))
        {
            SoundManager.instance.PlaySound("Zone2Music");
        }
    }
    void OnTriggerExit2D()
    {
        SoundManager.instance.StopSound();
    }
}
