using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endMenu;

    public void EndScreen()
    {
        endMenu.SetActive(true);
        Cursor.visible = true;
    }

}