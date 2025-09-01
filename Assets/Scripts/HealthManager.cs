using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    void Start()
    {
        // Initialize current health with max health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Check if the player is dead
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false); // Deactivate the player object
        }
    }

    /* Methods to calculate health damage */
    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth; // Reset current health to new max health
    }
}
