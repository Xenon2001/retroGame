using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float speed = 15f;
    private bool k;
    private float nr1=0f;
    private float nr2=0f;

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    
    
    void Start()
    {
        
        StartCoroutine(Pause());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1_Pong")
        {
            float y = hitFactor(transform.position , col.transform.position , col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "Player2_Pong")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    void FixedUpdate ()
    {
        if(this.transform.position.x >= 14f && nr1 < 4)
        {
            
            nr1++;
            this.transform.position = new Vector3(0f, 0.3f, 0f);
            k = !k;
            speed = 15f;
            StartCoroutine(Pause());
        }
        if(this.transform.position.x <= -14f && nr2 < 4)
        {
            nr2++;
            speed = 15f;
            this.transform.position = new Vector3(0f, 0.3f, 0f);
            k = !k;
            StartCoroutine(Pause());

        }
    }
    IEnumerator Pause ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
       yield return new WaitForSeconds(1f);
        if(k)
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        else
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(speed < 35)
        speed++;
    }
}
