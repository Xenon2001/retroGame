using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int noOfEnemies;

    public static float gameTime = 180f;
    public static float explosionTime = 0.5f;
    public static bool gameOver;
    public static bool win;
    public static bool activBomb;
    public static float bombTimer = 2f;
    public static Vector2 pos;



    void Awake()
    {
        gameTime = 180f;
        noOfEnemies = 0;
        win = false;
        gameOver = false;
        activBomb = false;
    }

    void FixedUpdate()
    {

        gameTime -= Time.deltaTime;
        if (explosionTime >= 0)
            explosionTime -= Time.deltaTime;
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
