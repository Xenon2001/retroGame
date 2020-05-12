using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameBegin : MonoBehaviour
{
    public GameObject canvasChild0;
    public GameObject canvasChild1;
    public GameObject canvasChild2;
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
    public Sprite Enemy0;
    public Sprite Enemy1;
    public Sprite Enemy2;
    public Sprite Enemy3;
    public Sprite Enemy4;
    public Sprite Enemy5;
    public Sprite Enemy6;
    public Sprite Enemy7;
    public Sprite Enemy8;
    public Sprite Enemy9;
    public End endScript;
    public class gameInProgress
    {
        public bool IsPlaying;
    }


    void Start()
    {
        string json1 = File.ReadAllText(Application.dataPath + "/Effects.json");
        effect ef = JsonUtility.FromJson<effect>(json1);

        string enemyJson= File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(enemyJson);

        switch (enemy.currentEnemyNr)
        {
            case "Enemy0":
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy0; animator.SetInteger("EnemyNr", 0); 
                    ef.bonus0 = 10; 
                    ef.bonus1 = 0; 
                    ef.bonus2 = 0; 
                    ef.bonus3 = 0; 
                    ef.bonus4 = 0; 
                    ef.bonus5 = 0;
                    string json2 = JsonUtility.ToJson(ef);
                    File.WriteAllText(Application.dataPath + "/Effects.json", json2);
                }
                break;
            case "Enemy1":
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy1; animator.SetInteger("EnemyNr", 1);
                    ef.bonus0 = 0;
                    ef.bonus1 = 10;
                    ef.bonus2 = 0;
                    ef.bonus3 = 0;
                    ef.bonus4 = 0;
                    ef.bonus5 = 0;
                }
                break;
            case "Enemy2"://boss1
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy2; animator.SetInteger("EnemyNr", 2);
                    ef.bonus0 = 10;
                    ef.bonus1 = 10;
                    ef.bonus2 = 0;
                    ef.bonus3 = 0;
                    ef.bonus4 = 0;
                    ef.bonus5 = 0;
                }
                break;
            case "Enemy3":
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy3; animator.SetInteger("EnemyNr", 3);
                    ef.bonus0 = 0;
                    ef.bonus1 = 0;
                    ef.bonus2 = 10;
                    ef.bonus3 = 0;
                    ef.bonus4 = 0;
                    ef.bonus5 = 0;
                }
                break;
            case "Enemy4":
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy4; animator.SetInteger("EnemyNr", 4);
                    ef.bonus0 = 0;
                    ef.bonus1 = 0;
                    ef.bonus2 = 0;
                    ef.bonus3 = 5;
                    ef.bonus4 = 0;
                    ef.bonus5 = 0;
                }
                break;
            case "Enemy5"://boss2
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy5; animator.SetInteger("EnemyNr", 5);
                    ef.bonus0 = 0;
                    ef.bonus1 = 0;
                    ef.bonus2 = 10;
                    ef.bonus3 = 5;
                    ef.bonus4 = 0;
                    ef.bonus5 = 0;
                }
                break;
            case "Enemy6":
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy6; animator.SetInteger("EnemyNr", 6);
                    ef.bonus0 = 0;
                    ef.bonus1 = 0;
                    ef.bonus2 = 0;
                    ef.bonus3 = 0;
                    ef.bonus4 = 1;
                    ef.bonus5 = 0;
                }
                break;
            case "Enemy7":
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy7; animator.SetInteger("EnemyNr", 7);
                    ef.bonus0 = 0;
                    ef.bonus1 = 0;
                    ef.bonus2 = 0;
                    ef.bonus3 = 0;
                    ef.bonus4 = 0;
                    ef.bonus5 = 10;
                }
                break;
            case "Enemy8"://boss3
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy8; animator.SetInteger("EnemyNr", 8);
                    ef.bonus0 = 0;
                    ef.bonus1 = 0;
                    ef.bonus2 = 0;
                    ef.bonus3 = 0;
                    ef.bonus4 = 1;
                    ef.bonus5 = 10;
                }
                break;
            case "Enemy9"://lastboss
                { 
                    gameObject.GetComponent<SpriteRenderer>().sprite = Enemy9; animator.SetInteger("EnemyNr", 9); 
                    ef.bonus0 = 0; 
                    ef.bonus1 = 10; 
                    ef.bonus2 = 0; 
                    ef.bonus3 = 5; 
                    ef.bonus4 = 1; 
                    ef.bonus5 = 0; 
                }
                break;
        }
        string efbonus = JsonUtility.ToJson(ef);
        File.WriteAllText(Application.dataPath + "/Effects.json", efbonus);

        T = 0;
        moveToConsole = false;
        cam = Camera.main;
        moveTimer = 1.5f;
        moveNext = false;
        Cardridge1.SetActive(false);
        Cardridge2.SetActive(false);
        Cardridge3.SetActive(false);

        if (enemy.nextEnemyNr == 10)
            endScript.EndScreen();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        string json = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");

        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(json);
        if (!IsPlayingVar&&combatScript.playerHP>0&& ("Enemy" + (enemy.nextEnemyNr).ToString()) == enemy.currentEnemyNr)
        {
            canvasChild0.SetActive(true);
            moveToConsole = true;
        }
        if (enemy.nextEnemyNr < Char.GetNumericValue(enemy.currentEnemyNr[5])) 
            canvasChild1.SetActive(true);
        if (enemy.nextEnemyNr > Char.GetNumericValue(enemy.currentEnemyNr[5])) 
            canvasChild2.SetActive(true);

    }
    void OnTriggerExit2D()
    {
        canvasChild0.SetActive(false);
        canvasChild1.SetActive(false);
        canvasChild2.SetActive(false);

    }
    void Update()
    {

        string checkEnd = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(checkEnd);
        if (enemy.nextEnemyNr == 10)
            endScript.EndScreen();

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
            if (PauseMenu.GameIsPaused)
            {
                Cardridge1.SetActive(false);
                Cardridge2.SetActive(false);
                Cardridge3.SetActive(false);
            }
            else
            {
                Cardridge1.SetActive(true);
                Cardridge2.SetActive(true);
                Cardridge3.SetActive(true);
            }
            
        }
        else if(moveToConsole)
        {
            moveScript.movement = new Vector2(0, 0);
            moveScript.canMove = false;
            T += Time.deltaTime;
            if (T >= moveTimer)
            {
                MovePlayers();
                if (player.position == waypoint2.position && transform.position == waypoint1.position&& combatScript.playerHP > 0&& combatScript.enemyHP >0)
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

    public class enemyToBattle
    {
        public string currentEnemyNr;
        public int nextEnemyNr;
    }
    public class effect
    {
        public int turn;
        public int bombermanDamageTurn1;
        public int bombermanDamageTurn2;
        public int noInvincibleTurn1;
        public int noInvincibleTurn2;
        public int whoReflectDamage;
        public int turnToReflect1;
        public int turnToReflect2;
        public int turnToStopPoison1;
        public int turnToStopPoison2;
        public int bonus0;
        public int bonus1;
        public int bonus2;
        public int bonus3;
        public int bonus4;
        public int bonus5;
    }
}
