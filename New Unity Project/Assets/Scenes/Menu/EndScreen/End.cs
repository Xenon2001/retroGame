using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endMenu;
    private bool end;

    void Update()
    {
        //CONDITIE DE END
        if (end)
        {
            endMenu.SetActive(true);

        }
    }

}