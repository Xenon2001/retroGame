using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] tetrisObject;
    public int index;

    
    void Start()
    {
     
        index = Random.Range(0, tetrisObject.Length);
        spawnRandom();
        
    }

    // Update is called once per frame
    public void spawnRandom()
    {

        GameObject[] blocks;
        blocks = GameObject.FindGameObjectsWithTag("Block");
        
        GameObject[] squares;
        squares = GameObject.FindGameObjectsWithTag("Square");

        foreach (GameObject block in blocks)
        {
            block.GetComponent<tetrisObject>().enabled = false;
        }
        
        foreach (GameObject square in squares)
        {
            if(matrixGrid.grid[(int)square.transform.position.y,(int)square.transform.position.x ] == null)
            {
                Destroy(square);
            }
        }




        Instantiate(tetrisObject[index], transform.position, Quaternion.identity);
        index = Random.Range(0, tetrisObject.Length);
    }

}
