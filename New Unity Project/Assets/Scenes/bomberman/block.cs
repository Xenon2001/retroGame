using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    public bool isEmpty;
    public bool isDestroyable;
    public bool isUndestroyable;
    public bool bomb;
    public float bombTimer = 2f;

    public Sprite emptySprite;
    public Sprite bombSprite;
    public Sprite destroyableSprite;
    public Sprite undestroyableSprite;


    public void loadNewSprite(int i)
    {
        /// 0 bomb 
        /// 1 empty
        /// 2 destroyable wall

        GetComponent<SpriteRenderer>().sprite = 
            (i == 0) ? bombSprite : (i == 1) ? emptySprite : destroyableSprite; 



    }

    void Start()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        if (this.CompareTag("empty") && (x >= 5 || y >= 5))
        {
            isDestroyable = UnityEngine.Random.value < 0.4;

            if (isDestroyable)
            {
                GetComponent<SpriteRenderer>().sprite = destroyableSprite;
                GetComponent<SpriteRenderer>().color = new Color(67, 67, 67);
                isEmpty = false;
                this.tag = "block_destroyable";
            }

        }

        if (this.CompareTag("block_destroyable") || this.CompareTag("block_undestroyable"))
        {
            this.gameObject.AddComponent<BoxCollider2D>();
        }
        map.grid[x, y] = this;
    }

    void Update()
    {

        /*/////////
         * function Update()
         {
             timeLeft -= Time.deltaTime;
             if ( timeLeft < 0 )
             {
                 GameOver();
             }
         }
        /////////*/
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        if (this.bomb)
        {
            //print(bombTimer.ToString());
            bombTimer -= Time.deltaTime;
        }
    }
}
