using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMovement : MonoBehaviour
{
    Vector2 dir;
    Vector3 rotation;
    public bool killed, isSuperPlayer;
    public int score, endScore;
    public float playerSpeed, superPlayerDuration;
    private Rigidbody2D rb;
    public PMEnemyMovement enemyScript;
    public float T;
    public Animator animator;

    void Awake()
    {
        T = 0;
        score = 0;
        endScore = 317;
        killed = false;
        dir = new Vector2(1, 0);
        isSuperPlayer = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!GameOver())
        {
            animator.SetBool("PPAP", isSuperPlayer);
            MoveInput();

            if(isSuperPlayer)
            {
                T += Time.deltaTime;
                if (T >= superPlayerDuration)
                { isSuperPlayer = false;T = 0; }
            }
        }
        else
        {
            if (score == endScore )
                scenesChange.gameToArcade("PacMan", true);
            else
                scenesChange.gameToArcade("PacMan", false);
        }

    }

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pmApple"&& col.gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            score++;
        }
        if (col.gameObject.tag == "pmEnemy" && col.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            if (isSuperPlayer)
            { 
                col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }

            else
                killed = true;
            
        if (col.gameObject.tag == "pmPineapple" && col.gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            score++;
            T = 0;
            isSuperPlayer = true;
        }
    }

    void Move()
    {
        if (!GameOver())
        {
            rb.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + dir, playerSpeed * Time.deltaTime);
        }
    }
    void MoveInput()
    {

        if (Input.GetAxis("Horizontal") > 0) //right 
        {

            dir = new Vector2(1, 0);
        }
        else if (Input.GetAxis("Vertical") > 0) //up
        {
            dir = new Vector2(0, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0) //left
        {
            dir = new Vector2(-1, 0);
        }
        else if (Input.GetAxis("Vertical") < 0) //down
        {
            dir = new Vector2(0, -1);
        }

    }


    bool GameOver()
    {
        if (score == endScore || killed)
            return true;
        return false;

    }

}