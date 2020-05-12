using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpInPlayerLaser : MonoBehaviour
{
    private float cooldownTimer = 0;
    private float fireDelay = 1f;
    public GameObject laserPrefab;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Instantiate(laserPrefab, new Vector3 (transform.position.x,transform.position.y-4.5f,0f),transform.rotation);
        }
    }
}
