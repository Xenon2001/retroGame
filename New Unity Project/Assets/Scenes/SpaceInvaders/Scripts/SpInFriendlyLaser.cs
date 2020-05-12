using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInFriendlyLaser : MonoBehaviour
{
    private float maxSpeed = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, maxSpeed);
        Destroy(gameObject, 1.5f);
    }

}
