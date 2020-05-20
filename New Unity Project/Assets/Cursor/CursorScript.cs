using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CursorScript : MonoBehaviour
{
    public Texture2D basicCursor;
    public Texture2D gameCursor;

    void Start()
    {
        Cursor.visible = false;
        Cursor.SetCursor(basicCursor, new Vector2(0, 0), CursorMode.ForceSoftware);

        Scene scene = SceneManager.GetActiveScene();

        if ( PauseMenu.GameIsPaused||scene.name == "Menu"||scene.name=="minesweeper")
        { 
            Cursor.visible = true;
            Cursor.SetCursor(basicCursor, new Vector2(0, 0), CursorMode.ForceSoftware); 
        }
        else
            Cursor.visible = false;
    }

}
