using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Renamer : ScriptableWizard
{
    [MenuItem("Custom/Rename")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Rename", typeof(Renamer), "Rename");
    }

    void OnWizardCreate()
    {
        GameObject[] kids = GameObject.FindGameObjectsWithTag("pmApple");
        for (int i = 0; i < kids.Length; i++)
        {
            string newName = "Apple11x10(" + i.ToString() + ")";
            kids[i].name = newName;
        }
    }
}
