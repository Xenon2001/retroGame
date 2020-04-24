using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class element : MonoBehaviour
{
    public bool isMine;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public static int noOfMines = 25;
    public static bool ok = true;

    void Start()
    {


        if (ok)
        {
            isMine = Random.value < 0.5;
            if (isMine)
                noOfMines--;
        }
        if (noOfMines == 0)
            ok = false;
       
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        playfield.elements[x, y] = this;

        
    }

    public void loadTexture(int count)
    {
         GetComponent<SpriteRenderer>().sprite = (isMine)? mineTexture : emptyTextures[count];
    }

    void OnMouseUpAsButton()
    {
        // It's a mine
        if (isMine)
        {
            playfield.uncoverMines();
            print("you lose");
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;

            loadTexture(playfield.adjacentMines(x, y));


            //Debug.Log("click on: "+ x);
            //Debug.Log("click on: " + y);
            playfield.fill(x, y, new bool[playfield.w, playfield.h]);

            if (playfield.isFinished())
                Debug.Log("you win");
        }
    }
    

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }
}