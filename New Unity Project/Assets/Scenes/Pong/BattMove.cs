using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattMove : MonoBehaviour
{
    public float speed = 5f;
    string input;

    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw(input);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, move) * speed;
    }
}
