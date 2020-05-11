using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class scenesChange : MonoBehaviour
{
    public Transform player;

    void mapToArcade()
    {
        /*INITIALIZARI EFECTE*/
        effect ef = new effect();
        ef.turn=0;
        ef.whoToExplode=0;
        ef.bombermanDamageTurn=-1;
        ef.whoNoDamage=0;
        ef.whoReflectDamage=0;
        ef.turnToReflect=-1;
        ef.whoPoisoned=0;
        ef.turnToStopPoison=-1;
    
    string json = JsonUtility.ToJson(ef);
        File.WriteAllText(Application.dataPath + "/Effects.json", json);

        /*THE ARCADE SCENE WILL RESTART */
        gameInProgress GIP = new gameInProgress();
        GIP.IsPlaying = false;
        string playing = JsonUtility.ToJson(GIP);
        File.WriteAllText(Application.dataPath + "/GameInProgress.json", playing);

        
        data Data = new data(); 
        Data.position = player.position;
       
        Data.position.y -= 2;
        string json1 = JsonUtility.ToJson(Data);

        File.WriteAllText(Application.dataPath + "/savefile.json", json1);
        
        SceneManager.LoadScene("Arcade");

    }
    void mapToShop()
    {
        data Data = new data();
        Data.position = player.position;

        Data.position.y -= 2;
        string json = JsonUtility.ToJson(Data);

        File.WriteAllText(Application.dataPath + "/savefile.json", json);

        SceneManager.LoadScene("Shop");

    }

    public void arcadeToMap()
    {
        string json = File.ReadAllText(Application.dataPath + "/savefile.json");

        data Data = JsonUtility.FromJson<data>(json);
        playerMovement.loadPosition(Data.position);
        spawnPoint.ifToSpawn(false);
        SceneManager.LoadScene("GamScene");
    }


    public static void gameToArcade(string name, bool win)
    {
        game Game = new game();

        Game.name = name;
        Game.win = win;

        string json = JsonUtility.ToJson(Game);

        File.WriteAllText(Application.dataPath + "/game.json", json);

        SceneManager.LoadScene("Arcade");
        
    }
    public void arcadeToGame(string game)
    {
        sceneData data = new sceneData();

        //data.enemyHP = CombatSystem.enemyHP;
        //data.HP = CombatSystem.HP;
        data.playerPosition = player.position;
        //data.enemyPosition = CombatSystem.enemy.transform.position;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/gameState.json", json);
        SceneManager.LoadScene(game);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Scene scene = SceneManager.GetActiveScene();
        //print(col.name + " " + scene.name);
        if (scene.name == "GamScene" && col.name == "Player")
        {
            if(gameObject.tag == "ArcadeTag")
                mapToArcade();
            if (gameObject.tag == "ShopTag")
                mapToShop();
        }
        if ((scene.name == "Arcade"||scene.name=="Shop") && col.name == "Player")
        {
            arcadeToMap();
        }
    }

    private class game
    {
        public string name;
        public bool win;
    }
    private class data
    {
        public Vector3 position;
    }
    private class sceneData
    {
        public int HP;
        public int enemyHP;
        public Vector3 playerPosition;
        public Vector3 enemyPosition;
        public bool IsGameGoing;
    }
    public class gameInProgress
    {
        public bool IsPlaying;
    }
    public class effect
    {
        public int turn;
        public int whoToExplode;
        public int bombermanDamageTurn;
        public int whoNoDamage;
        public int whoReflectDamage;
        public int turnToReflect;
        public int whoPoisoned;
        public int turnToStopPoison;
    }

}
