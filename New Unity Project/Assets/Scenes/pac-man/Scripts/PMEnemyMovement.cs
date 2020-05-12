using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMEnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float enemySpeed;
    public float spawnCooldown;
    float T;
    public Vector2 spawnPoint;
    int currentWaypoint;
    public bool toSpawn;

    void Start()
    {
        T = 0;
        toSpawn = true;
        currentWaypoint = 0;
        transform.position = waypoints[currentWaypoint].transform.position;
    }


    void Update()
    {
        if(gameObject.GetComponent<SpriteRenderer>().enabled ==false)
            toSpawn = true;
        if (toSpawn)
        {
             T+= Time.deltaTime;
            if (T >= spawnCooldown)
            {
                enemySpawn();
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                T = 0;   
            }
            toSpawn = false;
        }
        
        enemyMove();
    }
    void enemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, enemySpeed * Time.deltaTime);
        if(transform.position==waypoints[currentWaypoint].transform.position)
        {
            if(currentWaypoint<waypoints.Length-1)
            currentWaypoint++;
            else
                currentWaypoint = 1;

        }     
    }
    void enemySpawn()
    { 
        currentWaypoint = 0;
        transform.position = spawnPoint;
    }
}
