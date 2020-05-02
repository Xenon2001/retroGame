using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public static GameObject enemy;
    public static int HP = 100;
    public static int enemyHP = 100;

    void OnMouseOver()
    {
        transform.position += new Vector3(0,0.3f,0);
        if (Input.GetMouseButtonDown(0))
        {
            ;
        }
    }
}
