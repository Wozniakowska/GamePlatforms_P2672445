using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    public Text infoText;
    private int enemiesScore = 0;
    private bool gamePaused = false;

    void Start()
    {
        UpdateText();
    }

    public void Score()
    {
        // add 10 points everytime enemy die
        enemiesScore += 10;
        UpdateText();
    }

    private void UpdateText()
    {
        //Score text
        scoreText.text = "Score: " + enemiesScore.ToString();

        //If score is 200 enable you won text
        if (enemiesScore >= 200)
        {
            winText.text = "You Won!";
            infoText.text = "ON LEFT HAND MENU RESTART THE GAME";
            PauseGame();
        }
        else
        {
            //Default parameters
            winText.text = "";
            infoText.text = "";
        }
    }

    void PauseGame()
    {
        //Pause the game 
        Time.timeScale = 0f; 
        gamePaused = true;
    }
}

