using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int noOfEnemies;

    public static float gameTime = 180f;
    public static bool gameOver;
    public static bool win;
    public static bool activBomb;
    public static float bombTimer = 2f;
    public static Vector2 pos;



    void Awake()
    {
        noOfEnemies = 6;
        win = false;
        gameOver = false;
        activBomb = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        gameTime -= Time.deltaTime;
        if(gameTime < 0)
        {
            gameOver = true;
            win = false;
        }
        if (activBomb)
            bombTimer -= Time.deltaTime;

        if (gameOver)
            scenesChange.gameToArcade("bomberman", win);

        
    }
}
