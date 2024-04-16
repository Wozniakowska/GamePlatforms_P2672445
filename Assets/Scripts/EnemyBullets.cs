using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerPrefab;
    public Transform spawnLocaction;
    public float minShoot = 5f;
    public float maxShoot = 10f;
    private float shoot;
    public float bulletSpeed = 2f; 
    public float bulletLifetime = 3f; 
    private bool isPlayerAlive = true;
    private bool isEnemyAlive = true; 

    void Start()
    {
        // Set random time of shooting bullets towards the player
        shoot = Random.Range(minShoot, maxShoot);
        InvokeRepeating("ShootBullet", shoot, shoot);
    }

    void ShootBullet()
    {

        if (playerPrefab != null && bulletPrefab != null && isPlayerAlive && isEnemyAlive)
        {
            Vector3 directions = (playerPrefab.position - spawnLocaction.position).normalized;

            GameObject bulletObj = Instantiate(bulletPrefab, spawnLocaction.position, Quaternion.identity);

            Rigidbody bulletRigidbody= bulletObj.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                // Slow down the bullets for player comfortable escape
                bulletRigidbody.velocity = directions * bulletSpeed;
            }
            else
            {
                Debug.LogError("No rigidbody found");
            }

            //Destory the bullets after period of time 
            Destroy(bulletObj, bulletLifetime);
        }
        else
        {
        }
    }
    ///check if player alive
    public void EnablePlayer(bool alive)
    {
        isPlayerAlive = alive;
    }
    //Check if enemy alive
    public void EnableEnemy(bool alive)
    {
        isEnemyAlive = alive;
    }
}
