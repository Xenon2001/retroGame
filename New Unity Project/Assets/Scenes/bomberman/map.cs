using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class map : MonoBehaviour
{
    /// 0 bomb 
    /// 1 empty
    /// 2 destroyable wall

    public static int w = 51;
    public static int h = 11;
    public static int bombRange = 2;

    public static block[,] grid = new block[w, h];

    public Rigidbody2D rb;

    public bool inside(int x, int y)
    {
        return (x >= 0 && x < w && y >= 0 && y < h);
    }

    public void placeBomb(int x, int y)
    {
        grid[x, y].loadNewSprite(0);
        grid[x, y].isDestroyable = false;
        grid[x, y].isUndestroyable = false;
        grid[x, y].isEmpty = false;
        grid[x, y].bomb = true;
    }
    
    public void BOOM(int x, int y)
    {
        print("BOOOM");
        int[] dx = new int[4] { -1, 0, 1, 0 };
        int[] dy = new int[4] { 0, 1, 0, -1 };

        for(int i = 0; i < 4; ++i)
        {
            for(int j = 1; j <= bombRange; ++j)
            {
                int newX = x + dx[i] * j;
                int newY = y + dy[i] * j;

                

                if (inside(newX, newY))
                {
                    print(grid[newX, newY].tag);
                    if (grid[newX, newY].CompareTag("block_undestroyable"))
                        j = bombRange + 1;
                    if (grid[newX, newY].CompareTag("block_destroyable"))
                    {
                        grid[newX, newY].loadNewSprite(1);
                        grid[newX, newY].isDestroyable = false;
                        grid[newX, newY].isDestroyable = false;
                        grid[newX, newY].isEmpty = true;
                        grid[newX, newY].tag = "empty";
                        grid[newX, newY].GetComponent<BoxCollider2D>().enabled = false;
                        grid[newX, newY].GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                    }
                
                }

            } 
        }

    }

    void Update()
    {
        int x = Mathf.RoundToInt(rb.transform.position.x);
        int y = Mathf.RoundToInt(rb.transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (grid[x, y].CompareTag("empty"))
            {
              
                placeBomb(x, y);
                print("bomba la " + x + " " + y);
            }

        }

        for(int i = 0; i < w; ++i)
        {
            for(int j = 0; j < h; ++j)
            {
                if (grid[i, j].bomb && grid[i, j].bombTimer < 0)
                {
                    BOOM(i, j);
                    grid[i, j].loadNewSprite(1);
                    grid[i, j].bombTimer = 2f;
                    grid[i, j].isEmpty = true;
                    grid[i, j].bomb = false;
                }

                

            }
        }

    }


}
