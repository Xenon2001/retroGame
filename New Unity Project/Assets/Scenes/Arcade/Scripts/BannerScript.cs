using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BannerScript : MonoBehaviour
{
    public Sprite Banner0;
    public Sprite Banner1;
    public Sprite Banner2;
    public Sprite Banner3;
    public Sprite Banner4;
    public Sprite Banner5;
    public Sprite Banner6;
    public Sprite Banner7;
    public Sprite Banner8;
    public Sprite Banner9;
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");

        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(json);
        switch (enemy.currentEnemyNr)
        {
            case "Enemy0":
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner0; 
                }
                break;
            case "Enemy1":
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner1; 
                }
                break;
            case "Enemy2"://boss1
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner2; 
                }
                break;
            case "Enemy3":
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner3; 

                }
                break;
            case "Enemy4":
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner4; 

                }
                break;
            case "Enemy5"://boss2
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner5; 

                }
                break;
            case "Enemy6":
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner6; 

                }
                break;
            case "Enemy7":
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner7; 

                }
                break;
            case "Enemy8"://boss3
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner8; 

                }
                break;
            case "Enemy9"://lastboss
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Banner9;
                }
                break;
        }
    }
    public class enemyToBattle
    {
        public string currentEnemyNr;
        public int nextEnemyNr;
    }

}