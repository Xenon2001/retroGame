using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBegin : MonoBehaviour
{
    public GameObject canvasObject; 
    void OnTriggerEnter2D()
   {
        canvasObject.SetActive(true);

    }
    void OnTriggerExit2d()
    {
        canvasObject.SetActive(false);
    }
}
