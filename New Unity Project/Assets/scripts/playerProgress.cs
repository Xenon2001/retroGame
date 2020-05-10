using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playerProgress : MonoBehaviour
{
    /*void Start()
    {
        enemyToBattle enemy = new enemyToBattle();
        enemy.enemyNr = "Enemy0";

        string json = JsonUtility.ToJson(enemy);

        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json);

    }*/
    void OnTriggerEnter2D(Collider2D col)
    {
        enemyToBattle enemy = new enemyToBattle();
        print(col.gameObject.name);
        switch (col.gameObject.name)
        {
            case "Arcade00":
                enemy.enemyNr = "Enemy0";
                break;
            case "Arcade01":
                enemy.enemyNr = "Enemy1";
                break;
            case "Arcade02":
                enemy.enemyNr = "Enemy2";
                break;
            case "Arcade10":
                enemy.enemyNr = "Enemy3";
                break;
            case "Arcade11":
                enemy.enemyNr = "Enemy4";
                break;
            case "Arcade12":
                enemy.enemyNr = "Enemy5";
                break;
            case "Arcade20":
                enemy.enemyNr = "Enemy6";
                break;
            case "Arcade21":
                enemy.enemyNr = "Enemy7";
                break;
            case "Arcade22":
                enemy.enemyNr = "Enemy8";
                break;
            case "Arcade23":
                enemy.enemyNr = "Enemy9";
                break;
        }
        string json = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json);
    }
    public class enemyToBattle
    {
        public string enemyNr;
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