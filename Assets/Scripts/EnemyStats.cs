using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Scaling per Player Level")]
    public int healthPerLevel;
    public int damagePerLevel;

    [Header("Calculated Stats (Read-Only)")]
    public int finalHealth;
    public int finalDamage;

    private HealthManager healthManager;

    void Start()
    {
        healthManager = GetComponent<HealthManager>();

        // Find the player and calculate stats based on player's level
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) player = GameObject.Find("player");
        if (player != null)
        {
            CharacterStats playerStats = player.GetComponent<CharacterStats>();
            if (playerStats != null)
            {
                ScaleWithPlayerLevel(playerStats.currentLevel);
            }
        }
    }

    private void ScaleWithPlayerLevel(int playerLevel)
    {
        if (healthManager != null)
        {
            // Scaling existing maxHealth from HealthManager
            int scaledHealth = healthManager.maxHealth + (healthPerLevel * playerLevel);
            healthManager.UpdateMaxHealth(scaledHealth);
            finalHealth = healthManager.maxHealth; // Update finalHealth to reflect the new max health
            finalDamage = damagePerLevel * playerLevel;
        }
    }
}