using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandMenu : MonoBehaviour
{
    private bool gamePaused = true; 
    public string menuScene = "Menu";
    public PlayerController playerControls;
    private bool canDamage = true;

    public void TogglePause()
    {
        //Enable or disable pause inside the gamee
        gamePaused = !gamePaused;
        if (gamePaused)
        {
            GamePaused();
        }
        else
        {
            GameRun();
        }
       
    }

    public void ToggleDeathDamage(bool enableDamageAfterDeath)
    {
        playerControls.EnableDamage(!gamePaused && canDamage); // Enable/disable player taking damage based on pause state and death control
        canDamage = enableDamageAfterDeath;
    }

    void GamePaused()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
       
    }

    void GameRun()
    {
        Time.timeScale = 1f; // Set time scale back to 1 to resume the game

    }

    //Load menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}


