using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrixGrid : MonoBehaviour
{
    public static int row = 20;
    public static int column = 10;

    public static Transform[,] grid = new Transform[20,20];

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
    }

    public static bool isInideBorder(Vector2 v)
    {
        return ((int)v.x >= 0 && (int)v.x < column && (int)v.y >= 0);
    }


    public static bool isRowFull(int y)
    {
        
        for (int i = 0; i < column; ++i)
        {
            if(grid[y,i] == null)
            {
                return false;
            }
        }
        
        return true;
    }

 
    /// ////////////////////////////////////////////////////////
    public static void deleteRow(int y)
    {
        for(int i = y; i < row - 1; ++i)
        {
            for(int j = 0; j < column; ++j)
            {
                grid[i, j] = grid[i + 1, y];
                grid[i + 1, y] = null;
            }
        }
    }

    public static void deleteWholeRows()
    {
        
        for(int i = row -1 ; i > 0; --i)
        {
            if (isRowFull(i))
            {
                Debug.Log(i);
                deleteRow(i);
                i++;
            }
        }
    }










}

