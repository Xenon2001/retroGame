using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playerProgress : MonoBehaviour
{
   /* void Start()
    {
        enemyToBattle enemy = new enemyToBattle();
        enemy.currentEnemyNr = "Enemy0";
        string json = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json);
    }*/
    void OnTriggerEnter2D(Collider2D col)
    {
        enemyToBattle enemy = new enemyToBattle();

        switch (col.gameObject.name)
        {
            case "Arcade00":
                enemy.currentEnemyNr = "Enemy0";
                break;
            case "Arcade01":
                enemy.currentEnemyNr = "Enemy1";
                break;
            case "Arcade02":
                enemy.currentEnemyNr = "Enemy2";
                break;
            case "Arcade10":
                enemy.currentEnemyNr = "Enemy3";
                break;
            case "Arcade11":
                enemy.currentEnemyNr = "Enemy4";
                break;
            case "Arcade12":
                enemy.currentEnemyNr = "Enemy5";
                break;
            case "Arcade20":
                enemy.currentEnemyNr = "Enemy6";
                break;
            case "Arcade21":
                enemy.currentEnemyNr = "Enemy7";
                break;
            case "Arcade22":
                enemy.currentEnemyNr = "Enemy8";
                break;
            case "Arcade23":
                enemy.currentEnemyNr = "Enemy9";
                break;
            default:
                return;

        }
        string json = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json);
    }
    /*void OnTriggerExit2D()
    {
        enemyToBattle enemy = new enemyToBattle();
        enemy.currentEnemyNr = "Enemy0";
        string json = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json);
    }*/
    
    public class enemyToBattle
    {
        public string currentEnemyNr;
        public int nextEnemyNr;
    }
}
/*
 * daca a atins collider
 * daca nume collider este arcade1
 * pune sprite-ul coresp inamicului
 * scrie in json ce inamic tb sa bat next
 * lupta incepe doar daca e inamicul numerotat la fel cu cel ce tb next
 * 
 */