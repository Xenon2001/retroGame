using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone2 : MonoBehaviour
{
    //public SoundManager DJ;

    void Start()
    {
        //DJ.StopSound();
        SoundManager.instance.StopSound();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !SoundManager.instance.SoundIsPlaying("Zone2Music") /*!DJ.SoundIsPlaying("Zone2Music")*/)
        {
            //DJ.PlaySound("Zone2Music");
            FindObjectOfType<SoundManager>().PlaySound("Zone2Music");
        }
    }
    void OnTriggerExit2D()
    {
        //DJ.StopSound();
        SoundManager.instance.StopSound();
    }
}
