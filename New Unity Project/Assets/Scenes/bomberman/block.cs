using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    public bool isEmpty;
    public bool isDestroyable;
    public bool isUndestroyable;
    public bool exploded;

    public Sprite emptySprite;
    public Sprite bombSprite;
    public Sprite destroyableSprite;
    public Sprite undestroyableSprite;

    public Sprite explosionCenterSprite;
    public Sprite explosionLeftSprite;
    public Sprite explosionRightSprite;
    public Sprite explosionTopSprite;
    public Sprite explosionBottomSprite;

    public static GameObject player;

    public void loadNewSprite(int i)
    {
        GetComponent<SpriteRenderer>().sprite = 
            (i == 0) ? bombSprite : (i == 1) ? emptySprite : destroyableSprite; 
    }

    public void explosion(int i)
    {

        exploded = true;

        switch (i)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = explosionCenterSprite;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = explosionLeftSprite;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = explosionBottomSprite;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = explosionRightSprite;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = explosionTopSprite;
                break;  
        }
    }

    void Start()
    {

        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);


        transform.position = new Vector3(x, y, 0);



        if (!this.CompareTag("block_undestroyable"))
        {
            if (map.characteresCanMove(x, y))
            {
                isDestroyable = UnityEngine.Random.value < 0.4;

                if (isDestroyable)
                {

                    loadNewSprite(2);
                    this.tag = "block_destroyable";
                }

            }

        }  

        if(this.CompareTag("block_undestroyable"))
        {
            isUndestroyable = true;
        }    
                   

        

        if (this.CompareTag("block_destroyable") || this.CompareTag("block_undestroyable"))
        {
            this.gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            isEmpty = true;
        }

        this.gameObject.AddComponent<CircleCollider2D>();
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

        map.grid[x, y] = this;
    }


    

}
