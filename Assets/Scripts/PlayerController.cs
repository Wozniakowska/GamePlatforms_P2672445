using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 200; //Set to 200 cause so the player gets extra time of gameplay
    private int currentHealth;
    public Text playerDiedText; 
    public Text infoText; 
    private bool canTakeDamage = true;

    void Start()
    {
        //On Start:
        currentHealth = maxHealth;
        playerDiedText.enabled = false;
        infoText.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Collision check with the bullets
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            PlayersDamage(10); 
            Destroy(collision.gameObject);
        }
    }

    public void EnableDamage(bool enableDamage)
    {
        //Enable or disable damage
        canTakeDamage = enableDamage;
    }

    public void PlayersDamage(int damage)
    {
        // Control players health
        if (canTakeDamage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                PlayersDeath();
            }
        }
    }

    void PlayersDeath()
    {
        //Find the hand menu and enable playerdied, and also info text
        HandMenu handMenu = FindObjectOfType<HandMenu>(); 
        if (handMenu != null)
        {
            handMenu.ToggleDeathDamage(false); 
        }

        //Reset time
        Time.timeScale = 0f;
        //Enable  text
        playerDiedText.enabled = true;
        // Enable text
        infoText.enabled = true;
        // Set default text
        infoText.text = "ON LEFT HAND MENU RESTART THE GAME";
    }
}