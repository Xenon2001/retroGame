﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInControl : MonoBehaviour
{
    public float speed = 5f;
    string input;

    void Start()
    {
        input = gameObject.name;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw(input);
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, 0) * speed;
    }
   }