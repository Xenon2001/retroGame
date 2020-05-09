using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameBegin : MonoBehaviour
{
    public GameObject canvasObject;
    public bool moveNext,moveToConsole,IsPlayingVar;
    float T, moveTimer;
    public Transform player;
    public Transform waypoint1;
    public Transform waypoint2;
    public playerMovement moveScript;
    public CombatSystem combatScript;
    private Camera cam;
    public float zoomSpeed;
    public Animator animator;
    public GameObject Cardridge1;
    public GameObject Cardridge2;
    public GameObject Cardridge3;

    public class gameInProgress
    {
        public bool IsPlaying;
    }
    /*TO ADD AT GAMEOVER
         if(enemyHP==0)
         Defeated=true;
         else
        { movePlayerToSpwanPoint();
         playerHP=100;}
         */
    void Start()
    {
        T = 0;
        moveToConsole = false;
        cam = Camera.main;
        moveTimer = 1.5f;
        moveNext = false;
        Cardridge1.SetActive(false);
        Cardridge2.SetActive(false);
        Cardridge3.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!IsPlayingVar&&combatScript.playerHP>0/*&&!Defeated*/)
        {
            canvasObject.SetActive(true);
            moveToConsole = true;
        }
        
    }
    void OnTriggerExit2D()
    {
        canvasObject.SetActive(false);

    }
    void Update()
    {
        string json = File.ReadAllText(Application.dataPath + "/GameInProgress.json");

        gameInProgress GIP = JsonUtility.FromJson<gameInProgress>(json);
        IsPlayingVar = GIP.IsPlaying;
        
        if (IsPlayingVar)
        {
            animator.SetBool("IsPlaying", true);
            moveScript.animator.SetFloat("LastVertical", 1);
            moveScript.movement = new Vector2(0, 0);
            moveScript.canMove = false;
            player.position = waypoint2.position;
            transform.position = waypoint1.position;
            cam.transform.position = player.position + new Vector3(-0.5f, 0.5f, -10);
            cam.orthographicSize = 2;
            Cardridge1.SetActive(true);
            Cardridge2.SetActive(true);
            Cardridge3.SetActive(true);
        }
        else if(moveToConsole)
        {
            moveScript.movement = new Vector2(0, 0);
            moveScript.canMove = false;
            T += Time.deltaTime;
            if (T >= moveTimer)
            {
                MovePlayers();
                if (player.position == waypoint2.position && transform.position == waypoint1.position&& combatScript.playerHP > 0&&combatScript.enemyHP>0)
                {
                    IsPlayingVar = true;
                    gameInProgress GIP2 = new gameInProgress();
                    GIP2.IsPlaying = true;

                    string json2 = JsonUtility.ToJson(GIP2);

                    File.WriteAllText(Application.dataPath + "/GameInProgress.json", json2);
                }

            }
        }
        else
        {
            animator.SetBool("IsPlaying", false);
            moveScript.canMove = true;
            transform.position = new Vector3(0, 0, 0);
            cam.transform.position =new Vector3(0, 0,-10f);
            cam.orthographicSize = 5;
            Cardridge1.SetActive(false);
            Cardridge2.SetActive(false);
            Cardridge3.SetActive(false);
            combatScript.enemyHP = 100;
        }

    }
    void cameraZoom()
    {

        cam.transform.position = Vector3.MoveTowards(cam.transform.position, player.position + new Vector3(-0.5f, 0.5f, -10), 3 * Time.deltaTime);
        if (cam.orthographicSize >= 2)
            cam.orthographicSize -= zoomSpeed * Time.deltaTime;
    }

    void MovePlayers()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint1.position, 4f * Time.deltaTime);

        if (player.position != new Vector3(0, 0, 0) && !moveNext)
        {
            player.position = Vector3.MoveTowards(player.position, new Vector3(0, 0, 0), 3 * Time.deltaTime);
            moveScript.movement = new Vector2(0, 1);
        }
        else
        {
            moveNext = true;
            if (player.position != waypoint2.position)
            {
                player.position = Vector3.MoveTowards(player.position, waypoint2.position, 3 * Time.deltaTime);
                moveScript.movement = new Vector2(-1, 0); cameraZoom();
            }
        }
    }
}
