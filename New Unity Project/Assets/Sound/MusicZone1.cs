using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone1 : MonoBehaviour
{
    //public SoundManager DJ;

    void Start()
    {
        //DJ.StopSound();
        SoundManager.instance.StopSound();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !SoundManager.instance.SoundIsPlaying("Zone1Music") /* &&!DJ.SoundIsPlaying("Zone1Music")*/)
        {
;           // DJ.PlaySound("Zone1Music");
            SoundManager.instance.PlaySound("Zone1Music");
        }
    }
    void OnTriggerExit2D()
    {
        //DJ.StopSound();
        SoundManager.instance.StopSound();
    }
}
