using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject bodyPrefab;
    public FoodSpawner foodScript;
    private Vector3 snakeRotation;
    private Vector2 initialDirection,dir;
    public bool eaten;
    public int score, endScore, snakeLength;
    public float Border;
    public List<Vector2> SnakeBody;
    bool collided;
    void Awake()
    {
        eaten = true;
        score = 0;
        collided = false;
        initialDirection = new Vector2(1, 0);
        dir = initialDirection;
        SnakeBody = new List<Vector2>();
    }
    void Start()
    {
        
        InvokeRepeating("Move", 0.1f, 0.1f); 
        
    }
    void Update()
    {
        if (!GameOver())
        {
            MoveInput();
            EatApple();
        }
        else
        {
            if (score == endScore)
                scenesChange.gameToArcade("Snake", true);
            else
                scenesChange.gameToArcade("Snake", false);
        }

    }

    void MoveInput()
    {
        if (Input.GetAxis("Horizontal") > 0 && snakeRotation.z != 180) //right 
        {
            dir = new Vector2(1, 0);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 0;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        else if (Input.GetAxis("Vertical") > 0 && snakeRotation.z != 270) //up
        {
            dir = new Vector2(0, 1);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 90;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        else if (Input.GetAxis("Horizontal") < 0 && snakeRotation.z != 0) //left
        {
            dir = new Vector2(-1, 0);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 180;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
        else if (Input.GetAxis("Vertical") < 0 && snakeRotation.z != 90) //down
        {
            dir = new Vector2(0, -1);
            snakeRotation = transform.rotation.eulerAngles;
            snakeRotation.z = 270;
            transform.rotation = Quaternion.Euler(snakeRotation);
        }
    }

    void EatApple()
    {
        if ((Vector2)transform.position == foodScript.applePosition)
        {
            Destroy(GameObject.FindWithTag("Apple"));
            eaten = true;
            snakeLength++;
            score++;
        }
    }
    void Move()
    {
        SnakeBody.Insert(0, transform.position);
        Vector2 intent = (Vector2)transform.position + dir;
        for (int i = 1; i < SnakeBody.Count; i++)
            if (SnakeBody[i] == intent || intent.x > Border|| intent.x < -Border|| intent.y>Border|| intent.y<-Border)
                collided=true;
        if (!GameOver())
        {
            transform.Translate(initialDirection);
            if (SnakeBody.Count >= snakeLength + 1)
            {
                SnakeBody.RemoveAt(SnakeBody.Count - 1);
            }

            for (int i = 0; i < SnakeBody.Count; i++)
            {
                GameObject bodyPart = Instantiate(bodyPrefab, SnakeBody[i], Quaternion.identity);
                Destroy(bodyPart, 0.1f);
            }
        }
        
        
    }

    bool GameOver()
    {

        if (score == endScore || collided)
            return true;
        return false;
        
    }
  
}
