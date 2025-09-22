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

    [Header("Scaling Enemy Per Level")]
    public CharacterStats playerStats;
    public int healthPerLevel;
    public int damagePerLevel;
    public int defencePerLevel;
    public int expRewardPerLevel;

    void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        // Update enemy stats based on level
        if (playerStats != null)
        {   
            int currentLevel = playerStats.currentLevel;
            healthManager.UpdateMaxHealth(baseHealth + (healthPerLevel * (currentLevel - 1)));
            // You can similarly update damage, defense, and exp reward if needed
        }
        else
        {
            Debug.LogWarning("CharacterStats component not found on " + gameObject.name);
        }
    }
}
