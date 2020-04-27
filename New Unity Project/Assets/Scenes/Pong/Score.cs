using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scoreboard;
    public GameObject ball;
    private int Bat_1_Score = 0;
    private int Bat_2_Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x >= 14f && Bat_1_Score<5)
        {
            Bat_1_Score++;
        }
        if (ball.transform.position.x <= -14f&& Bat_2_Score<5)
        {
            Bat_2_Score++;
        }
        if(Bat_1_Score < 5 && Bat_2_Score < 5)
        Scoreboard.text = Bat_1_Score.ToString() + " - " + Bat_2_Score.ToString();
        else
        {
             if (Bat_1_Score >= 5)
                 Scoreboard.text = "LEFT WINS";
             else
                 Scoreboard.text = "RIGHT WINS";
        }
    }
}
