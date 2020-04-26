using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombermanCamera : MonoBehaviour
{
    public Transform target;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Update()
    {

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = targetPosition;
        }


    }
}

