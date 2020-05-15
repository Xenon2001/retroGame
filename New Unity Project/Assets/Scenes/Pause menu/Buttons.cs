using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Buttons : MonoBehaviour
{
    public PauseMenu function ;
    public Rigidbody2D rb;

    public void MainMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        lastPos position = new lastPos();
        position.pos = rb.position;
        position.scene = currentScene.name;
        string json = JsonUtility.ToJson(position);
        File.WriteAllText(Application.dataPath + "/lastPos.json", json);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

     public void Resume()
    {
        function.Resume();
    }
    public class lastPos
    {
        public Vector3 pos;
        public string scene;
    }
}
