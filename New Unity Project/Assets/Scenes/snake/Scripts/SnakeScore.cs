using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeScore : MonoBehaviour
{
    public GameScript gScript;
    public Text scoreText;


    void Update()
    {
        if (gScript.score > gScript.endScore)
            gScript.score--;
        scoreText.text = "Score: " + gScript.score.ToString() + "/" + gScript.endScore.ToString();
    }
}
