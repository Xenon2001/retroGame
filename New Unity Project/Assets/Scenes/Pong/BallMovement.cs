using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
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
    void Update ()
    {
        if(this.transform.position.x >= 13.5f)
        {
            this.transform.position = new Vector3(0f, 0f, 0f);
        }
        if(this.transform.position.x <= -13.5f)
        {
            this.transform.position = new Vector3(0f, 0f, 0f);
        }
    }

    // Update is called once per frame
}
