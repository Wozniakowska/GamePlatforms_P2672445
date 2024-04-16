using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour
{
    private bool gamePaused = true; 

    void Start()
    {
        // At the start pause the game 
        PauseGame(); 
    }

    public void TogglePause()
    {
        //Control the button either pause or unpause
        gamePaused = !gamePaused;

        if (gamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        //Game time = 0 (Stop the game)
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        //Game time = 1 (Play the game)
        Time.timeScale = 1f; 
       
    }
}
