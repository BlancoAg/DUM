using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    public bool shielded = false;
    public bool big = true;
    public bool biggering;
    public bool shrinking;
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject gameOverPanel;
    public GameObject Crosshair;
    private FirstPersonController firstPersonController;

    void Start()
    {
        currentHealth = maxHealth;
        firstPersonController = GetComponent<FirstPersonController>();
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
     gameOverPanel.SetActive(true);
     firstPersonController.enabled = false;
     Cursor.lockState = CursorLockMode.None;
     Cursor.visible = true;
     Crosshair.SetActive(false);

    }
}
