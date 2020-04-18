using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneChance;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
                
        if (collision.CompareTag("Player"))
        {
            if(sceneChance == "next")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  - 1);
            }
            
        }
    }
}
