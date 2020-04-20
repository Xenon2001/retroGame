using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    private Vector2 minPosition;
    private Vector2 maxPosition;

    private float[,] cameraBounds = new float[5,4] {
        {-4.61f, -10.96f, 35.5f, 13.75f},
        {18.44f, -45.89f, 58.44f, -21.09f},
        {83.32f, -60.76f, 123.28f, -36.09f},
        {133.31f, -25.93f, 173.33f, -1.13f},
        {198.07f, -3.86f, 238.02f, 20.81f}
    };

    private float[,] player = new float[5,4] {
        {-16.61f, -15.97f, 47.60f, 18.72f},
        {6.34f, -50.88f, 70.55f, -15.98f},
        {71.20f, -65.85f, 135.41f, -31.02f},
        {121.14f, -31.01f, 185.34f, 3.914f},
        {185.35f, -8.976f, 250.21f, 25.822f}
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
