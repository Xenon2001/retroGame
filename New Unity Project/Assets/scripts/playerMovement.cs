using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
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
