using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInEnemyMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public int k = 0;
    public float fallAmount = 1f;
    private bool ok;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
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
                if(k%2==1)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                else
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                ok = true;
                transform.position = new Vector3(transform.position.x, transform.position.y - fallAmount, 0f);
                speed += 0.04f;
            }
        }
        else ok = false;
    }
}

