using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInEnemyShooting : MonoBehaviour
{
    GameObject[] enemys;
    GameObject shooter;
    int index;
    private float cooldownTimer = 0;
    private float fireDelay = 1.25f;
    public GameObject laserPrefab;
    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("SpInEnemy");

    }


   void Update()
   {
        if(enemys.Length==0)
            scenesChange.gameToArcade("SpaceInvaders", true);
        cooldownTimer -= Time.deltaTime;
    if (cooldownTimer <= 0 )
        if( enemys.Length >= 0)
        {  
          
         cooldownTimer = fireDelay;
         fire();
        }
   }
    void fire ()
    {
        enemys = GameObject.FindGameObjectsWithTag("SpInEnemy");
        index = Random.Range(0, enemys.Length);
        if (enemys.Length > 0)
        {
            shooter = enemys[index];
            Instantiate(laserPrefab, new Vector3(enemys[index].transform.position.x, enemys[index].transform.position.y, 0f), transform.rotation);
        }
    }
    
}
