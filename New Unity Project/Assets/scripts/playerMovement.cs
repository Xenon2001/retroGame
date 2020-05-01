using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    static Vector3 initPos = new Vector3(-10, 10, 0);
    Vector2 movement;

    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "ZONE I")
            rb.transform.position = initPos;
        
    }

    public static void loadPosition(Vector3 v)
    {
        initPos = v;
    }

    void Update() {

        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", movement.x);

        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.sqrMagnitude > 1)
            movement = movement.normalized;

    }

    void FixedUpdate() {
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }


}
