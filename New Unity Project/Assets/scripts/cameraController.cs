using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    private Vector2 minPosition;
    private Vector2 maxPosition;

    private float[,] cameraBounds = new float[5,4] {
        {-9.47f, -11.02f, 40.58f, 13.96f},
        {13.47f, -45.89f, 63.54f, -21.02f},
        {78.39f, -60.88f, 128.3f, -36.04f},
        {128.32f, -25.98f, 178.18f, -1.15f},
        {193.21f, -4.08f, 243.13f, 20.88f}
    };




    private float[,] player = new float[5,4] {
        {-16.56f, -15.97f, 47.46f, 17.96f},
        {6.41f, -50.84f, 70.5f, -16.98f},
        {71.22f, -65.84f, 120.45f, -31.92f},
        {121.18f, -30.94f, 185.34f, 3.01f},
        {186f, -8.9f, 250.18f, 24.97f}
    };


    void Update()
    {


        Vector2 playerPosition = target.position;
        
        for(int i = 0; i < 5; i++)
        {
            if (player[i, 0] <= playerPosition.x && playerPosition.x <= player[i,2] &&
                player[i, 1] <= playerPosition.y && playerPosition.y <= player[i,3] )
            {
                Debug.Log(minPosition.x);
                Debug.Log(minPosition.y);
                Debug.Log(maxPosition.x);
                Debug.Log(maxPosition.y);
                minPosition.x = cameraBounds[i, 0];
                minPosition.y = cameraBounds[i, 1];
                maxPosition.x = cameraBounds[i, 2];
                maxPosition.y = cameraBounds[i, 3];
            }
        }

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = targetPosition;
        }


    }
}
