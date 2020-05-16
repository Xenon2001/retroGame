using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class scenesChange : MonoBehaviour
{
    public Transform player;
    bool isCoroutineExecuting;
    public Animator transition;
    public playerMovement moveScript;

    void mapToArcade()
    {
        SoundManager.instance.StopSound();

        /*INITIALIZE EFFECTS*/
        effect ef = new effect();
        ef.turn=0;
        ef.bombermanDamageTurn1 = ef.bombermanDamageTurn2 = -1;
        ef.noInvincibleTurn1 = ef.noInvincibleTurn2 =- 1;
        ef.whoReflectDamage=0;
        ef.turnToReflect1 = ef.turnToReflect2 = -1;
        ef.turnToStopPoison1= ef.turnToStopPoison2 = -1;

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
        StartCoroutine(mapToArcadeCor());

    }
    IEnumerator mapToArcadeCor()
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;

        /*Showing the loading transition*/
        moveScript.canMove = false;
        moveScript.canMove2 = false;
        moveScript.movement = new Vector2(0, 0);
        transition.SetBool("ZoneChange", true);

        yield return new WaitForSeconds(3f);
        transition.SetBool("ZoneChange", false);
        moveScript.canMove = true;
        moveScript.canMove2 = true;
        SceneManager.LoadScene("Arcade");
        isCoroutineExecuting = false;
    }
    void mapToShop()
    {
        moveScript.canMove = false;
        moveScript.canMove2 = false;
        moveScript.movement = new Vector2(0, 0);
        transition.SetBool("ZoneChange", true);

        data Data = new data();
        Data.position = player.position;

        Data.position.y -= 2;
        string json = JsonUtility.ToJson(Data);

        File.WriteAllText(Application.dataPath + "/savefile.json", json);
        StartCoroutine(mapToShopCor());
    }
    IEnumerator mapToShopCor()
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(3f);
        transition.SetBool("ZoneChange", false);
        moveScript.canMove = true;
        moveScript.canMove2 = true;
        SceneManager.LoadScene("Shop");
        isCoroutineExecuting = false;
    }

    public void arcadeToMap()
    {
        string json = File.ReadAllText(Application.dataPath + "/savefile.json");

        data Data = JsonUtility.FromJson<data>(json);
        playerMovement.loadPosition(Data.position);
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

        data.playerPosition = player.position;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/gameState.json", json);
        SceneManager.LoadScene(game);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "GamScene" && col.name == "Player")
        {
            if(gameObject.tag == "ArcadeTag")
                mapToArcade();
            if (gameObject.tag == "ShopTag")
                mapToShop();
        }
        if ((scene.name == "Arcade"||scene.name=="Shop") && col.name == "Player")
        {
            spawnPoint.ifToSpawn(false);
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
        public int bombermanDamageTurn1;
        public int bombermanDamageTurn2;
        public int noInvincibleTurn1;
        public int noInvincibleTurn2;
        public int whoReflectDamage;
        public int turnToReflect1;
        public int turnToReflect2;
        public int turnToStopPoison1;
        public int turnToStopPoison2;
    }

}
