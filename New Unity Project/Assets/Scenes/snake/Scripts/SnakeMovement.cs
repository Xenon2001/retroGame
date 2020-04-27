using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public GameObject bodyPrefab;
    public float movementSpeed = 1;
    public int snakeLength;
    Vector3 snakeRotation;
    Vector2 direction=new Vector2(1,0);
    public List<GameObject> sb = new List<GameObject>(); //sb=snakeBody

    void Start()
    {
       GameObject bodyPart = Instantiate(bodyPrefab, new Vector3(-1,-1,0), Quaternion.identity); ;
        for(int i=0;i<3;i++)
        sb.Add(bodyPart);
        sb[0].transform.position = new Vector3(3, 3, 0);
        InvokeRepeating("Move", 0.3f, 0.3f);       
    }
    void Update()
    {
        if(Input.GetAxis("Horizontal")>0 && snakeRotation.z!=180 /*&& direction!=new Vector2(-1,0)*/) //right 
        {
            //direction = new Vector2(1, 0);
            //snakeRotation = new Vector3(0, 0, 180);
            snakeRotation= transform.rotation.eulerAngles;
            snakeRotation.z = 0;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        else if (Input.GetAxis("Vertical")> 0 && snakeRotation.z != 270/*&& direction != new Vector2(0, -1)*/) //up
        {
            //direction = new Vector2(0, 1);
            //snakeRotation = new Vector3(0, 0, 90);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 90;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        else if (Input.GetAxis("Horizontal") < 0 && snakeRotation.z != 0/* && direction != new Vector2(1, 0)*/) //left
        {
            //direction = new Vector2(-1, 0);
            // snakeRotation = new Vector3(0, 0, -180);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 180;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        else if (Input.GetAxis("Vertical")< 0 && snakeRotation.z != 90/*&& direction != new Vector2(0, 1)*/) //down
        {
            //direction = new Vector2(0, -1);
            // snakeRotation = new Vector3(0, 0, -90);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 270;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        //if(collided with tail/wall) lose

    }
    void Move()
    {

            transform.Translate(direction);
    }

}
