using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour
{
    public GameObject Ef1, Ef2, Ef3, Ef4;
    public Text txt1, txt2, txt3;

    public void Effect1(int turns)
    {
        if(turns>0)
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
    public void Effect1(bool active)
    {
        if (active)
        {
            Ef3.SetActive(true);
        }
        else
        {
            Ef3.SetActive(false);
        }
    }
}
