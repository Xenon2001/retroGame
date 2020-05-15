using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneChange : MonoBehaviour
{
    public Transform player;
    public Animator transition;
    public playerMovement moveScript;
    bool isCoroutineExecuting;

    void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.name == "Player")
        {
            moveScript.canMove = false;
            moveScript.canMove2 = false;
            moveScript.movement = new Vector2(0, 0);
            transition.SetBool("ZoneChange", true);
            if (gameObject.name == "NextZone")
                player.position += new Vector3(2, 0, 0);
            if (gameObject.name == "PreviousZone")
                player.position += new Vector3(-2, 0, 0);
            StartCoroutine(ChangeZone());
           
        }
    }
    IEnumerator ChangeZone()
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(3f);
        transition.SetBool("ZoneChange", false);
        moveScript.canMove = true;
        moveScript.canMove2 = true;
        isCoroutineExecuting = false; 
    }
    

}
