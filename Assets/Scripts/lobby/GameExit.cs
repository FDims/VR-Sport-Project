using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check for a specific input (e.g., Escape key) to exit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    // Function to exit the game
    public void ExitGame()
    {
        // This will only work in a standalone build (not in the Unity Editor)
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        // In the Unity Editor, stop the play mode
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

