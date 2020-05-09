using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playfield : MonoBehaviour
{
    public static int w = 10;
    public static int h = 13;
    public static element[,] elements = new element[w,h];
    

    public static int[] dx = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
    public static int[] dy = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };



    public static void uncoverMines()
    {
        foreach (element elem in elements)
            if (elem.isMine && !elem.flag)
                elem.loadTexture(0);
      
    }

    public static bool isFinished()
    {
       
        foreach (element elem in elements)
            if (elem.isCovered() && !elem.isMine)
                return false;
        
        return true;
    }

  

    public static bool inside(int x, int y)
    {
        return (x >= 0 && x < w && y >= 0 && y < h);
    }

    public static void fill(int x, int y, bool[,] viz)
    {
     
        if (viz[x, y])
            return;
        else
        {
               
            viz[x, y] = true;

            int sth = adjacentMines(x, y);

            elements[x, y].loadTexture(sth);

            if (sth > 0)
                return;

            for (int i = 0; i < 8; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];               
                if (inside(newX, newY))
                {                 
           
                    fill(newX, newY, viz);
                }
               
            }
        }
    }

    public static int adjacentMines(int x, int y)
    {
        int k = 0;

        for(int i = 0; i < 8; ++i)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];
            if(inside(newX, newY))
            {
                
                if (elements[newX,newY].isMine)
                    ++k;               
            }
        }
        return k;
    }          


}
