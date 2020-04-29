using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInDamage : MonoBehaviour
{
    private int hp = 1;


    void Start()
    {

    }


    void Update()
    {
        if (hp <= 0)
        {
            Erase();
        }
    }
    void OnTriggerEnter2D()
    {
        hp--;
    }
    void Erase()
    {
        Destroy(gameObject);
    }
}
