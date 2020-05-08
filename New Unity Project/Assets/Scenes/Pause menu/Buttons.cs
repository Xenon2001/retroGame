using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public PauseMenu function ;
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

     public void Resume()
    {
        function.Resume();
    }
}
