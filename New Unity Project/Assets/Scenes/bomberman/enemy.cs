using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int minRange = 10;
    public int dir = 1;
    public float lastMove = 0.3f; 
    public bool onX;
    public bool onY;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        map.enemies[GameController.noOfEnemies++] = this;
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameController.gameOver = true;
            GameController.win = false;
        }
    }

    bool canMove(int x, int y, char c)
    {
        if (c == 'x')
            return ((map.inside(x - 1, y) && map.grid[x - 1, y].isEmpty) || (map.grid[x + 1, y].isEmpty && map.inside(x + 1, y)));
        else
            return ((map.inside(x, y - 1) && map.grid[x, y - 1].isEmpty) || (map.inside(x, y + 1) && map.grid[x, y + 1].isEmpty));
    }

    void Update()
    {
        int newX, newY;

        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);

        Vector3 move = new Vector3(0, 0, 0);


        lastMove -= Time.deltaTime;

        if(lastMove < 0)
        {

            bool switchAxes = Random.value < 0.3f;
            if (switchAxes)
            {
                if (onX)
                {
                    if(canMove(x,y,'y'))
                    {
                        onX = false;
                        onY = true;
                    }
                }
                else
                {
                    if (canMove(x, y, 'x'))
                    {
                        onX = true;
                        onY = false;
                    }
                }
            }
            
            newX =x;
            newY =y;

            if (onX)
                newX += dir;
            else
                newY += dir;

            bool notOnBomb = true;

            if (GameController.activBomb)
            {
                int PlayerX = Mathf.RoundToInt(GameController.pos.x);
                int PlayerY = Mathf.RoundToInt(GameController.pos.y);

                notOnBomb = !((newX == PlayerX) && (newY == PlayerY));
            }


            if (map.inside(newX, newY) && map.grid[newX,newY].isEmpty && notOnBomb)
            {

                move = new Vector3((onX) ? dir : 0, (onY) ? dir : 0, 0);
            }
            else
            {
                dir *= -1;
                newX = x + ((onX) ? dir : 0);
                newY = y + ((onY) ? dir : 0);
                if (map.inside(newX, newY) && map.grid[newX, newY].isEmpty && notOnBomb)
                {
                    move = new Vector3((onX) ? dir : 0, (onY) ? dir : 0, 0);
                }
            }
                
            
            transform.position += move;

            lastMove = 0.45f;
        }



    }
}
