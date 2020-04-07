using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilebasedMovement : MonoBehaviour
{
    public float movementSpeed;
    public Animator animator;
    public Transform followedPoint;
    private Vector3 movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", movement.x);

        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.position = Vector3.MoveTowards(transform.position, followedPoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, followedPoint.position) <=0.1f)
        {
            if (!Physics2D.OverlapCircle(followedPoint.position + movement, 0.3f))
            {
                followedPoint.position += movement;
            }
        }
    }
}
