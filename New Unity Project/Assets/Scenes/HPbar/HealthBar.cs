using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text hpAmount;
    public Gradient gradient;
    public Image fill;
    void Start()
    {
        string Hp = File.ReadAllText(Application.dataPath + "/HPs.json");

        HP hps = JsonUtility.FromJson<HP>(Hp);
        SetHealth(hps.playerHP);
        gradient.Evaluate(1f);

    }
    public void SetHealth(int health)
    {
        slider.value = health;
        hpAmount.text = health + "/100";
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public class HP
    {
        public int enemyHP;
        public int playerHP;
    }
}
