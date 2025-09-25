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
    private DamagePlayer damagePlayer;
    private int lastPlayerLevel = -1;
    private int originalBaseHealth;
    private int originalBaseDamage;

    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        damagePlayer = GetComponent<DamagePlayer>();
        originalBaseHealth = healthManager.maxHealth;
        originalBaseDamage = damagePlayer.damage;
    }

    void Update()
    {

        // Find the player and calculate stats based on player's level
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) player = GameObject.Find("player");
        if (player != null)
        {
            CharacterStats playerStats = player.GetComponent<CharacterStats>();
            if (playerStats != null)
            {
                if (playerStats.currentLevel != lastPlayerLevel)
                {
                    ScaleWithPlayerLevel(playerStats.currentLevel);
                    lastPlayerLevel = playerStats.currentLevel; // Update last known player level
                }
            }
        }
    }

    private void ScaleWithPlayerLevel(int playerLevel)
    {
        if (healthManager != null)
        {
            finalHealth = originalBaseHealth + (healthPerLevel * (playerLevel - 1));
            Debug.Log("Scaling Enemy Health: " + finalHealth);
            finalDamage = originalBaseDamage + (damagePerLevel * (playerLevel - 1));
            Debug.Log("Scaling Enemy Damage: " + finalDamage);

            // Update the HealthManager's max health if it has changed
            healthManager.UpdateMaxHealth(finalHealth);

            // Update the DamagePlayer's damage if it has changed
            damagePlayer.UpdateDamage(finalDamage);
        }
    }
}