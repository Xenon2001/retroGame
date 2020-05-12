using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongEnemy : MonoBehaviour
{
    public float speed = 6f;
    private GameObject ball;

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    void Update()
    {
        if (ball.transform.position.x > 0f)
        {
            if (transform.position.y < 5.4f && transform.position.y > -5.4f)
            {
                transform.position = Vector3.MoveTowards(
                                                    transform.position,
                                                    new Vector3(transform.position.x, ball.transform.position.y, 0f),
                                                    speed * Time.deltaTime
                                                    );
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                                            transform.position,
                                            new Vector3(transform.position.x, 0f, 0f),
                                            speed * Time.deltaTime
                                            );
        }
    }
}
