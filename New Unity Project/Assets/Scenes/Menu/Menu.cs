using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{

    void Start()
    {
        SoundManager.instance.StopSound();
        SoundManager.instance.PlaySound("MenuMusic");
    }
    public void PlayGame()
    {
        SoundManager.instance.StopSound();
        HP hp = new HP();
        hp.playerHP = 100;
        hp.enemyHP = 100;
        string json = JsonUtility.ToJson(hp);
        File.WriteAllText(Application.dataPath + "/HPs.json", json);
        
        zona Zone = new zona();
        Zone.x = "zona1";
        string json2 = JsonUtility.ToJson(Zone);
        File.WriteAllText(Application.dataPath + "/zona.json", json2);

        enemyToBattle enemy = new enemyToBattle();
        enemy.currentEnemyNr = "Enemy0";
        enemy.nextEnemyNr = 0;
        string json3 = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json3);

        spawnPoint.ifToSpawn(true);

        SceneManager.LoadScene("GamScene");

        Cursor.visible = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        SoundManager.instance.StopSound();
        string json1 = File.ReadAllText(Application.dataPath + "/lastPos.json");
        lastPos position = JsonUtility.FromJson<lastPos>(json1);
        playerMovement.loadPosition(position.pos);
        spawnPoint.ifToSpawn(false);
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene(position.scene);

        Cursor.visible = false;
    }
    private class data
    {
        public Vector3 position;
    }
    public class HP
    {
        public int enemyHP;
        public int playerHP;
    }
    public class zona
    {
        public string x;
    }
    public class enemyToBattle
    {
        public string currentEnemyNr;
        public int nextEnemyNr;
    }
    public class lastPos
    {
        public Vector3 pos;
        public string scene;
    }
}
