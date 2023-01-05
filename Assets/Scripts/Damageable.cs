using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
     SceneManager.LoadScene(currentSceneIndex - 1);   // Do something when the character dies, such as play a death animation or destroy the game object
    }
}
