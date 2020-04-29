using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameScript gScript;
    public Transform borderTop, borderBot, borderLeft, borderRight;
    public Vector2 applePosition;

    void LateUpdate()
    {
        if (gScript.eaten && gScript.score < gScript.endScore)
        { 
            SpawnApple(); 
            gScript.eaten = false;
        }      
    }

    void SpawnApple()
    {
        float x, y;
        do
        {
            x = (int)Random.Range(borderLeft.position.x, borderRight.position.x - 1f);
            y = (int)Random.Range(borderTop.position.y - 1f, borderBot.position.y);
            x += 0.5f;
            y += 0.5f;
            applePosition = new Vector2(x, y);
        }
        while (Physics2D.OverlapCircle(applePosition, 0.1f));
        Instantiate(applePrefab, applePosition, Quaternion.identity);
    }


    
}

