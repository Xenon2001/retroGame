using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInDamage : MonoBehaviour
{
    //public GameObject[] enemys;
    private int hp = 1;


    void Start()
    {
       // enemys = GameObject.FindGameObjectsWithTag("SpInEnemy");
    }


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
        //enemys = GameObject.FindGameObjectsWithTag("SpInEnemy");
    }
}
