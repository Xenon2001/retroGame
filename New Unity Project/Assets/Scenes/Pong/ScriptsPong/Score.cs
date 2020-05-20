using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scoreboard;
    private GameObject minge;
    private int Bat_1_Score = 0;
    private int Bat_2_Score = 0;
    private bool ok;
    private bool ook;

    void Start()
    {
        minge = GameObject.Find("Ball");
    }

    void Update()
    {
        if (minge.transform.position.x >= 14f && Bat_1_Score < 3)
        {
            if (!ok)
            {
                Bat_1_Score++;
                ok = true;
            }

        }
        else ok = false;
        if (minge.transform.position.x <= -14f && Bat_2_Score < 3)
        {
            if (!ook)
            {
                Bat_2_Score++;
                ook = true;
            }
        }
        else ook = false;

        if (Bat_1_Score < 3 && Bat_2_Score < 3)
        {
            Scoreboard.text = Bat_1_Score + " - " + Bat_2_Score;
            
        }
        else
        {
            if (Bat_1_Score >= 3)
                scenesChange.gameToArcade("Pong", true);
            else
                scenesChange.gameToArcade("Pong", false);
        }
    }
}