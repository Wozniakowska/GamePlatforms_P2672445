using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    public float hoverHeight = 1.0f;
    public float hoverSpeed = 1.0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        MoveEnemies();
    }
    void MoveEnemies()
    {
        // Bounce the enemies up and down to give some animation 
        float newY = initialPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
