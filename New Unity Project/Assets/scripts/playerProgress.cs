using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playerProgress : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        string json = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");

        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(json);

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
        
        string json1 = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json1);
    }
    
    public class enemyToBattle
    {
        public string currentEnemyNr;
        public int nextEnemyNr;
    }
}
