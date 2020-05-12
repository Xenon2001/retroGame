using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class spawnPoint : MonoBehaviour
{
    public Transform target;
    static bool toSpawn;
    public GameObject spawnPointMessage;
    public class zona
    {
        public string x;
    }
    public static void ifToSpawn(bool w)
    {
        toSpawn = w;
    }
    void Awake()
    {
        Vector2 spawnPoint = new Vector2(0f, 0f);

        Vector2 zona1 = new Vector2(-10.39f, 11.16f);
        Vector2 zona2 = new Vector2(308.58f, 21.46f);
        Vector2 zona3 = new Vector2(556.03f, 35.44f);



        string json = File.ReadAllText(Application.dataPath + "/zona.json");

        zona Zona = JsonUtility.FromJson<zona>(json);

        if (Zona.x == "zona1")
            spawnPoint = zona1;
        if (Zona.x == "zona2")
            spawnPoint = zona2;
        if (Zona.x == "zona3")
            spawnPoint = zona3;
        if(toSpawn)
        playerMovement.loadPosition(new Vector3(spawnPoint.x, spawnPoint.y, 0));

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        spawnPointMessage.SetActive(true);

        zona Zona = new zona();
        
        if(this.name == "House0") {
            Zona.x = "zona1";
        }
        if(this.name == "Hotel0") {
            Zona.x = "zona2";
        }
        if(this.name == "Hotel1") {
            Zona.x = "zona3";
        }

        string json = JsonUtility.ToJson(Zona);
        File.WriteAllText(Application.dataPath + "/zona.json", json);
        
    }

    void OnTriggerExit2D()
    {
        spawnPointMessage.SetActive(false);
    }
}
