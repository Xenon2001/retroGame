using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minesweeperUI : MonoBehaviour
{
    public Text NoOfMines;

 

    void Update()
    {
        NoOfMines.text = "Mines: " + (element.noOfMines - element.noOfFlags).ToString();
    }
}
