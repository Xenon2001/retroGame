using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform borderTop, borderBot, borderLeft, borderRight, snakeTransform;
    Vector2 applePosition;
    bool eaten;
    int score;
    public int endScore;
    int snakelength;
    GameObject snakehead;

    /*void Awake()
    {
        snakehead = GameObject.FindWithTag("SnakeHead");
    }*/
    void Start()
    {
        snakelength = GameObject.FindWithTag("SnakeHead").GetComponent<SnakeMovement>().snakeLength;
        eaten = true;
        score = 0;
    }
    void Update()
    {
        if (eaten && score < endScore)
        { 
            SpawnApple(); 
            eaten = false;
            snakelength++;
            score++;
        }
        if ((Vector2)snakeTransform.position == applePosition)
        { 
            Destroy(GameObject.FindWithTag("Apple")); 
            eaten = true; 
        }

    }

    void SpawnApple()
    {
        float x = (int)Random.Range(borderLeft.position.x, borderRight.position.x-1f);
        float y = (int)Random.Range(borderTop.position.y-1f, borderBot.position.y);
        x += 0.5f;
        y += 0.5f;
        applePosition = new Vector2(x, y);
        Instantiate(applePrefab, applePosition, Quaternion.identity);
    }

}

