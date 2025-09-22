using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Player base Stats")]
    public int baseLevel;
    public int baseHealth;
    public int baseDamage;
    public int baseDefense;
    public int baseExpReward;

    private HealthManager healthManager;
    private CharacterStats playerStats;

    [Header("Scaling Enemy Per Level")]
    public int healthPerLevel;
    public int damagePerLevel;
    public int defencePerLevel;
    public int expRewardPerLevel;

    [Header("Calculated Enemy Stats")]
    public int currentHealth;
    public int currentDamage;
    public int currentDefence;
    public int currentExpReward;

    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        Debug.Log("EnemyStats: HealthManager obtained: " + (healthManager != null));

        // Validate base stats first
        if (baseHealth <= 0)
        {
            Debug.LogWarning("EnemyStats: baseHealth is 0 or negative! Setting to 10.");
            baseHealth = 10;
        }

        // Find the player and get their CharacterStats component - try multiple methods
        GameObject player = null;

        // Method 1: Try finding by tag
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("EnemyStats: Player found by tag: " + (player != null));

        // Method 2: Try finding by name "player" (lowercase)
        if (player == null)
        {
            player = GameObject.Find("player");
            Debug.Log("EnemyStats: Player found by name 'player': " + (player != null));
        }

        // Method 3: Try finding by name "Player" (capitalized)
        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("EnemyStats: Player found by name 'Player': " + (player != null));
        }

        if (player != null)
        {
            playerStats = player.GetComponent<CharacterStats>();
            if (playerStats != null)
            {
                Debug.Log("EnemyStats: CharacterStats found. Player level: " + playerStats.currentLevel);
                CalculateEnemyStats();
            }
            else
            {
                Debug.LogWarning("CharacterStats component not found on player. Using default stats.");
                SetDefaultStats();
            }
        }
        else
        {
            Debug.LogWarning("Player GameObject not found in the scene. Using default stats.");
            SetDefaultStats();
        }
    }

    /* Add these new methods at the end of the class */
    private void CalculateEnemyStats()
    {
        int playerLevel = playerStats.currentLevel;
        Debug.Log("EnemyStats: Calculating stats for player level: " + playerLevel);

        // Calculate scaled stats based on player level
        currentHealth = baseHealth + (healthPerLevel * playerLevel);
        currentDamage = baseDamage + (damagePerLevel * playerLevel);
        currentDefence = baseDefense + (defencePerLevel * playerLevel);
        currentExpReward = baseExpReward + (expRewardPerLevel * playerLevel);

        // Ensure health is always positive
        if (currentHealth <= 0)
        {
            Debug.LogWarning("EnemyStats: Calculated health is 0 or negative! Setting to 1.");
            currentHealth = 1;
        }

        Debug.Log("EnemyStats: Final calculated health: " + currentHealth);

        // Update the HealthManager with the calculated health
        if (healthManager != null)
        {
            healthManager.UpdateMaxHealth(currentHealth);
            healthManager.expWhenDefeated = currentExpReward; // Set exp reward in HealthManager
            Debug.Log("EnemyStats: HealthManager updated successfully");
        }
        else
        {
            Debug.LogError("EnemyStats: HealthManager is null!");
        }
    }

    /* Fallback method */
    private void SetDefaultStats()
    {
        Debug.Log("EnemyStats: Using default stats");

        // Ensure base stats are valid
        if (baseHealth <= 0) baseHealth = 10;
        if (baseDamage < 0) baseDamage = 1;
        if (baseDefense < 0) baseDefense = 0;
        if (baseExpReward < 0) baseExpReward = 5;

        currentHealth = baseHealth;
        currentDamage = baseDamage;
        currentDefence = baseDefense;
        currentExpReward = baseExpReward;

        Debug.Log("EnemyStats: Default health set to: " + currentHealth);

        if (healthManager != null)
        {
            healthManager.UpdateMaxHealth(currentHealth);
            healthManager.expWhenDefeated = currentExpReward; // Set exp reward in HealthManager
            Debug.Log("EnemyStats: HealthManager updated with default stats");
        }
        else
        {
            Debug.LogError("EnemyStats: HealthManager is null in SetDefaultStats!");
        }
    }
}
