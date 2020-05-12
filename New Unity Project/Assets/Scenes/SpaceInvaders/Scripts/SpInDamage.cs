using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInDamage : MonoBehaviour
{
    private int hp = 1;


    void Update()
    {
        if (hp <= 0)
        {
            if(this.name =="SpaceShip")
                scenesChange.gameToArcade("SpaceInvaders", false);
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
