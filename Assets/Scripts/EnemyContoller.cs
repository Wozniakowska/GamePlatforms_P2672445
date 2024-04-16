using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContoller : MonoBehaviour
{
    public int BEGINHealth = 100;
    private int currentHealth;
    public float respawn= 5f;
    private Vector3 initialPosition;
    private bool isItDead = false;
    public GameObject explosionPrefab;
    public Transform player;
    public PointManager pointManager; 

    void Start()
    {
        currentHealth = BEGINHealth;
        initialPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.CompareTag("Bullet"))
        {
            //if the bullets collided take damage of 20.
            TakeDamage(20); 
        }
    }
    void Update()
    {
        
        if (player != null)
        {
            //Caluclate direction from objects to the player current position
            Vector3 directionToPlayer = player.position - transform.position;

           // create rotation so the enemy looks at the player 
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

            // Set the rotation.
            transform.rotation = targetRotation;
        }
    }
    void TakeDamage(int damage)
    {
        //Take damage from the player
        if (!isItDead)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        ///When the enemy dies disable the object, update the score and respawn
        isItDead = true;    
        gameObject.SetActive(false);
        pointManager.Score();
        //create explosion prefab after enemy death
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Invoke("Respawn", respawn);
    }

    void Respawn()
    {
        //Reset the stats and enable the enemy back into the game
        currentHealth = BEGINHealth;
        transform.position = initialPosition;
        gameObject.SetActive(true);
        isItDead = false;
    }
}
