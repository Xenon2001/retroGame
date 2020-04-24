using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisObject : MonoBehaviour
{
    float lastFall = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
            transform.position += new Vector3(-1, 0, 0);

            if (!isValidGridPosition())
                transform.position += new Vector3(1, 0, 0);             
           
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
          
                transform.position += new Vector3(1, 0, 0);

                if (!isValidGridPosition())      
                    transform.position += new Vector3(-1, 0, 0);
                
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    
                    transform.Rotate(new Vector3(0, 0, -90));

                    if (!isValidGridPosition())                   
                        transform.Rotate(new Vector3(0, 0, 90));
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 0.5f)
                    {
                       
                        transform.position += new Vector3(0, -1, 0);

                        if (isValidGridPosition())
                            lastFall = Time.time;
                        else
                        {
                            
                            transform.position += new Vector3(0, 1, 0);

                            updateMatrix();
                            matrixGrid.deleteWholeRows();                   
                            FindObjectOfType<Spawner>().spawnRandom();

                        }
                    }
                }
            }  
        }

        updateMatrix();
    }

    bool isValidGridPosition()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = matrixGrid.roundVec2(child.position);

            if(matrixGrid.isInideBorder(v) == false)
            {
                return false;
            }

            if (matrixGrid.grid[(int)v.y, (int)v.x] != null &&
                matrixGrid.grid[(int)v.y, (int)v.x].parent != transform)                                                                                                                                                                                                         
            {
                
                return false;
            }

        }

        return true;
    }
    void updateMatrix()
    {

        for (int y = 0; y < matrixGrid.column; ++y)
        {
            for (int x = 0; x < matrixGrid.row; ++x)
            {
                if (matrixGrid.grid[x, y] != null)
                {
                    if (matrixGrid.grid[x, y].parent == transform)
                    {
                        matrixGrid.grid[x, y] = null;
                    }
                }
            }
        }
        Debug.Log(matrixGrid.isRowFull(0));

        foreach (Transform child in transform)
        {
            Vector2 v = matrixGrid.roundVec2(child.position);

            matrixGrid.grid[(int)v.y, (int)v.x] = child; 
        }
    }

    

}
