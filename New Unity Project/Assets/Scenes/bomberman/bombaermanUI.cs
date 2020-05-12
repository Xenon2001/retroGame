using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bombaermanUI : MonoBehaviour
{
    public Text Timer;
    public Text Enemies;

    string timeFormat(float s, bool micro)
    {
        if (micro)
            s *= 100;

        s = Mathf.RoundToInt(s);


        if (micro)
            return "0:" + s;
        else
            return (int)(s / 60) + ":" + (s % 60);
    }

    void Update()
    {
        Timer.text = "TIME: " + timeFormat(GameController.gameTime,false);   

        Enemies.text = "ENEMIES: " + GameController.noOfEnemies.ToString();

    }
}
