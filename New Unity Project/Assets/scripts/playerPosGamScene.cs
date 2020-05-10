using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playerPosGamScene : MonoBehaviour
{
    public Rigidbody2D rb;

    void Update()
    {
        lastPos position = new lastPos();
        position.pos=rb.position;
        string json = JsonUtility.ToJson(position);
        File.WriteAllText(Application.dataPath + "/lastPos.json", json);
    }
    public class lastPos
    {
        public Vector3 pos;
    }
}