using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class HPRestore : MonoBehaviour
{
    public HealthBar playerHPScript;
    public GameObject canvasObject;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Shop")
        {
            SoundManager.instance.StopSound();
            SoundManager.instance.PlaySound("ShopMusic");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string json1 = File.ReadAllText(Application.dataPath + "/HPs.json");
        HP Hp = JsonUtility.FromJson<HP>(json1);

        if (Hp.playerHP < 100)
        {
            if (gameObject.name == "Shopkeeper"||gameObject.name=="BuffedShopkeeper")
                canvasObject.SetActive(true); 
            Hp.playerHP = 100;
            string json2 = JsonUtility.ToJson(Hp);
            File.WriteAllText(Application.dataPath + "/HPs.json", json2);
            playerHPScript.SetHealth(100);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        canvasObject.SetActive(false);
    }
    public class HP
    {
        public int enemyHP;
        public int playerHP;
    }
}
