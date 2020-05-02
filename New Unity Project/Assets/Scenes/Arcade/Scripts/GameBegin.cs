using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBegin : MonoBehaviour
{
    public GameObject canvasObject;
    public bool beginFight,toMoveNext;
    float T, moveTimer;
    public Transform player;
    public Transform waypoint1;
    public Transform waypoint2;
    public playerMovement moveScript;
    private Camera cam;
    public float zoomSpeed;
    public Animator animator;
    void Start()
    {
        cam = Camera.main;
        beginFight = false;
        T = 0;
        moveTimer = 3f;
    }
    void OnTriggerEnter2D(Collider2D col)
   {
            canvasObject.SetActive(true);
            beginFight = true;
    }
    void OnTriggerExit2D()
    {
        canvasObject.SetActive(false);
        
    }
    void Update()
    {
        animator.SetBool("IsPlaying", moveScript.IsPlaying);
        if (beginFight)
        {  
            moveScript.movement = new Vector2(0, 0);
            moveScript.canMove = false;
            
            T += Time.deltaTime;
            if (T >= moveTimer)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint1.position, 4f * Time.deltaTime);
                if (!toMoveNext)
                {
                    player.position = Vector3.MoveTowards(player.position, new Vector3(0, 0, 0), 3 * Time.deltaTime);
                    if (player.position != new Vector3(0, 0, 0))
                        moveScript.movement = new Vector2(0, 1);
                    else
                        toMoveNext = true;
                }
                else
                {
                    cameraZoom();
                    player.position = Vector3.MoveTowards(player.position, waypoint2.position, 3 * Time.deltaTime);
                    if (player.position != waypoint2.position)
                        moveScript.movement = new Vector2(-1, 0);
                    else
                    { 
                        moveScript.movement = new Vector2(0, 0);
                        moveScript.IsPlaying = true;
                    }
                }
                
            }       
        }
    }
    void cameraZoom()
    {

            cam.transform.position= Vector3.MoveTowards(cam.transform.position, player.position+new Vector3(-0.5f,0.5f,-10), 3*Time.deltaTime);
            if (cam.orthographicSize>=2)
            cam.orthographicSize -= zoomSpeed*Time.deltaTime;
    }
}
