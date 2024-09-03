using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    [SerializeField] private int currentHealth;


    void Start()
    {
        // Initialize player healt
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
            GameOver();
        }

    }
    void Die()
    {
        // Add logic for player death, e.g, play animation, show game over screen
        Debug.Log("PLayer Died");
        Destroy(gameObject); //Destroy the player GameObject
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision object is an enemy bullet
        enemyBullet bullet = collision.GetComponent<enemyBullet>();
        if (bullet != null && bullet.isEnemy)
        {
            TakeDamage(1); // Assume each bullet does 1 damage

            Destroy(bullet.gameObject); // Destroy the bullet
        }

    }

    void GameOver()
    {
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an enemy
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Die(); // Player dies instantly on contact with the enemy
            GameOver();
        }
    }
}
