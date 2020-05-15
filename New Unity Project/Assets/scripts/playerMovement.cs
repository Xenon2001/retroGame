using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public float speed,lastVerticalDir;
    public Rigidbody2D rb;
    public Animator animator;
    static Vector3 initPos;
    public Vector2 movement;
    public bool canMove;
    public bool canMove2;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GamScene")
            rb.transform.position = initPos;
        canMove = canMove2 = true;
        lastVerticalDir = 0;
    }

    public static void loadPosition(Vector3 v)
    {
        initPos = v;
    }

    void Update() {
        if (canMove)
        {
            movement.y = Input.GetAxisRaw("Vertical");
            movement.x = Input.GetAxisRaw("Horizontal");
        }
        if (canMove2)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.y > 0)
            lastVerticalDir = 1;
        else if (movement.y < 0)
            lastVerticalDir = -1;
        if (canMove)
            animator.SetFloat("LastVertical", lastVerticalDir);
        if (movement.sqrMagnitude > 1)
            movement = movement.normalized;

    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }


}
