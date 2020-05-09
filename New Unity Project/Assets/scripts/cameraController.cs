using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class cameraController : MonoBehaviour
{
    public Transform target;
    private Vector2 minPosition;
    private Vector2 maxPosition;

    private float[,] cameraBounds = new float[14,4] {
        {-7.94f, -10.89f, 38.93f, 13.84f},
        {14.92f, -45.82f, 61.84f, -21.07f},
        {79.87f, -60.82f, 126.81f, -36.21f},
        {129.74f, -25.8f, 176.78f, -1.07f},
        {194.8f, -3.89f, 241.56f, 20.84f},

        {259.43f, 20.97f, 305.6f, 45.72f},
        {323.37f, 37.89f, 369.54f, 62.78f},
        {387.52f, 24.9f, 442.06f, 54.57f},
        {425.49f, 59.95f, 471.52f, 84.76f},
        {474.52f, 24.92f, 520.52f, 49.77f},


        {538.44f, 32.9f, 584.59f, 57.86f},
        {562.45f, 67.95f, 608.6f, 92.8f},
        {524.44f, 102.92f, 570.65f, 125.11f},
        {397.47f, 102.95f, 506.69f, 127.78f}
    };




    private float[,] player = new float[14, 4] {
        {-16.56f, -15.99f, 47.54f, 18.73f},
        {6.46f, -50.86f, 70.5f, -16.19f},
        {71.26f, -65.86f, 135.44f, -31.34f},
        {121.22f, -30.94f, 185.27f, 3.85f},
        {186.34f, -8.75f, 250.12f, 25.51f},

        {250.93f, 15.87f, 314.17f, 50.57f},
        {314.9f, 32.92f, 378.2f, 67.64f},
        {378.9f, 19.92f, 442.06f, 54.57f},
        {416.9f, 54.9f, 480.16f, 89.69f},
        {465.9f, 19.9f, 529.23f, 54.73f},


        {529.92f, 27.92f, 593.15f, 62.74f},
        {553.96f, 63.97f, 617.07f, 97.66f},
        {515.96f, 97.95f, 579.05f, 122.79f},
        {389.04f, 97.97f, 514.94f, 132.62f}
    };



    void Update()
    {


        Vector2 playerPosition = target.position;
        
        for(int i = 0; i < 14; i++)
        {
            if (player[i, 0] <= playerPosition.x && playerPosition.x <= player[i,2] &&
                player[i, 1] <= playerPosition.y && playerPosition.y <= player[i,3] )
            {
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
