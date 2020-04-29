using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int minRange = 10;
    public bool onX;
    public bool onY;

    void Awake()
    {
        map.enemies[GameController.noOfEnemies++] = this;
    }
    void Start()
    {
        
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameController.gameOver = true;
            GameController.win = false;
        }
        print(GameController.gameOver);
    }
    void Update()
    {
        
    }
}
