using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInEnemyMovement : MonoBehaviour
{
    public float speed;
    public int k;
    public float fallAmount;
    private bool ok;
    void Start()
    {
        speed = 1f;
        k = 0;
        fallAmount = 0.5f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        if (transform.position.y <= -10.5)
            scenesChange.gameToArcade("SpaceInvaders", false);
        if (transform.position.x < 0 || transform.position.x > 4)
        {
            if (!ok)
            {
                k++;
                if (k % 2 == 1)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                else
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                ok = true;
                transform.position = new Vector3(transform.position.x, transform.position.y - fallAmount, 0f);
                speed += 0.05f;
            }
        }
        else ok = false;
    }
}

