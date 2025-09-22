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
        int currentLevel = baseLevel; // This could be set dynamically based on game logic
        int currentHealth = baseHealth + (healthPerLevel * (currentLevel - 1));
    }
}
