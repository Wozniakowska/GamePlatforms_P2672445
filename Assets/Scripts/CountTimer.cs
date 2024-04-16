using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimer : MonoBehaviour
{
    public float timerDuration = 60f; 
    private float timer = 0f;
    public Text timerText; 
    public Text gameOverText; 
    public Text infoText; 
    public Light pointLight; 
    private float blinkInterval = 0.5f; 
    private float blinkingTimer = 0f;
    private bool startBlinking = false;

    void Start()
    {
      
        UpdateTimerText();

        pointLight.enabled = false;
        gameOverText.enabled = false;
        infoText.enabled = false;
    }

    void Update()
    {
        if (!startBlinking && timer >= 50f)
        {
            startBlinking = true;
            // for player comfort only blink 4 times
            StartCoroutine(BlinkTime(4)); 
        }

       // update timer using deltatime
        timer += Time.deltaTime;

       // update the text
        UpdateTimerText();

        // check if the 1 min has gone yet
        if (timer >= timerDuration)
        {
            PauseGame();
        }
    }

     void PauseGame()
    {
        Time.timeScale = 0f; 
        gameOverText.enabled = true;
        infoText.enabled = true;
        infoText.text = "ON LEFT HAND MENU RESTART THE GAME";
    }
    void UpdateTimerText()
    {
       
        int mins = Mathf.FloorToInt(timer / 60f);
        int secs = Mathf.FloorToInt(timer % 60f);
      //format the timer so its more readable
        timerText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }

    IEnumerator BlinkTime(int time)
    {
        for (int i = 0; i < time * 2; i++)
        {
            pointLight.enabled = !pointLight.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}