using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class element : MonoBehaviour
{
    public bool isMine;
    public bool flag;
    public static bool fsClick = true;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public Sprite flagTexture;
    public Sprite defaultTexture;
    public static int noMaxOfMines = 20;
    public static int noOfMines = 0;
    public static int noOfFlags = 0;
    public static bool ok = true;

    void Awake()
    {
        noMaxOfMines = 20;
        noOfMines = 0;
        noOfFlags = 0;
        ok = true;
    }

    void Start()
    {


        if (ok)
        {
            isMine = Random.value < 0.5;
            if (isMine)
                noOfMines++;
        }
        if (noOfMines >= noMaxOfMines)
            ok = false;
       
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        playfield.elements[x, y] = this;

        
    }

    public void loadTexture(int count)
    {
         GetComponent<SpriteRenderer>().sprite = (isMine)? mineTexture : emptyTextures[count];
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(flag || isCovered())
            {
                GetComponent<SpriteRenderer>().sprite = (flag) ? defaultTexture : flagTexture;
                flag = !flag;
                if (flag)
                    noOfFlags++;
                else
                    noOfFlags--;
            }
               
        }
        if (Input.GetMouseButtonDown(0) && !flag)
        {
            if (fsClick)
            {
                if (isMine)
                {
                    int newX = (int)transform.position.x;
                    int newY = (int)transform.position.y;

                    while (playfield.elements[newX, newY].isMine)
                    {
                        newX = Random.Range(0, playfield.w);
                        newY = Random.Range(0, playfield.h);
                    }

                    isMine = false;
                    playfield.elements[newX, newY].isMine = true;

                }

                fsClick = false;
            }
            

            if (isMine)
            {
                playfield.uncoverMines();
                scenesChange.gameToArcade("minesweeper", false);
            }
            else
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;

                loadTexture(playfield.adjacentMines(x, y));

                playfield.fill(x, y, new bool[playfield.w, playfield.h]);

                if (playfield.isFinished())
                    scenesChange.gameToArcade("minesweeper", true);
            }
        }

            
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }


}