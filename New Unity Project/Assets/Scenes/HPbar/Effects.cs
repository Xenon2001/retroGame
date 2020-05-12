using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Effects : MonoBehaviour
{
    public GameObject Ef1, Ef2, Ef3, Ef4;
    public Text txt1, txt2, txt3;

    void Update()
    {
        string json = File.ReadAllText(Application.dataPath + "/GameInProgress.json");
        gameInProgress GIP = JsonUtility.FromJson<gameInProgress>(json);
        if(!GIP.IsPlaying)
        { 
            Effect1(0);
            Effect2(0);
            Effect3(0);
            Effect4(false);
        }    
    }
    public void Effect1(int turns)
    {
        
        if (turns>0)
        {
            Ef1.SetActive(true);
            txt1.text = turns.ToString();
        }
        else
        {
            Ef1.SetActive(false);
        }
    }
    public void Effect2(int turns)
    {
        if (turns > 0)
        {
            Ef2.SetActive(true);
            txt2.text = turns.ToString();
        }
        else
        {
            Ef2.SetActive(false);
        }
    }
    public void Effect3(int turns)
    {
        if (turns > 0)
        {
            Ef3.SetActive(true);
            txt3.text = turns.ToString();
        }
        else
        {
            Ef3.SetActive(false);
        }
    }
    public void Effect4(bool active)
    {
        if(active)
        {
            Ef4.SetActive(true);
        }
        else
        {
            Ef4.SetActive(false);
        }
    }

    public class gameInProgress
    {
        public bool IsPlaying;
    }
}
