using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text hpAmount;

    public void SetHealth(int health)
    {
        slider.value = health;
        hpAmount.text = health + "/100";
    }

}
