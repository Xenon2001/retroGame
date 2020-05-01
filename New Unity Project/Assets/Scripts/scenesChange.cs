using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class scenesChange : MonoBehaviour
{

    public GameObject player;

    void mapToArcade()
    {
        data Data = new data(); 
        Data.position = player.transform.position;

        Data.position.x -= 2;

        string json = JsonUtility.ToJson(Data);

        File.WriteAllText(Application.dataPath + "/savefile.json", json);

        SceneManager.LoadScene("Arcade");

    }

    void arcadeToMap()
    {
        string json = File.ReadAllText(Application.dataPath + "/game.json");

        data Date = JsonUtility.FromJson<data>(json);


        SceneManager.LoadScene("ZONA I");
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

    void OnTriggerEnter2D(Collider2D col)
    {
        Scene scene = SceneManager.GetActiveScene();
        print(col.name);
        if (scene.name == "ZONA I" && col.name == "Player")
        {
            mapToArcade();
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



}
