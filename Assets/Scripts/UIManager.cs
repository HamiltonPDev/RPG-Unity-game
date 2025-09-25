using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    // References to UI elements
    [Header ("Player Health Elements")]
    public Slider PlayerHealthBar;
    public Text PlayerHealthText;
    public HealthManager playerHealthManager;

    [Header("Player Stats")]
    public Text PlayerLevelText;    
    public Text PlayerCurrentExpText;
    public CharacterStats playerStats;

    [Header ("Strength")]
    public Text PlayerStrengthText;
    private WeaponDamage playerWeaponDamage;

    [Header ("Enemies Stats")]
    public Text EnemyDamageText;
    public Text EnemyHealthText;
    private EnemyStats enemyStats;

    void Start()
    {
        playerWeaponDamage = FindFirstObjectByType<WeaponDamage>();
        enemyStats = FindFirstObjectByType<EnemyStats>();
    }

    void Update()
    {
        /* update health UI */
        int maxHealth = playerHealthManager.maxHealth;
        int currentHealth = playerHealthManager.currentHealth;

        /* Update Player stats */
        int currentLevel = playerStats.currentLevel;
        int currentExp = playerStats.currentExp;

        /* Update Strength stats*/
        int Strength = playerWeaponDamage.totalPlayerDamage;

        /* Update Enemy stats */
        int enemyHealth = enemyStats.finalHealth;
        int enemyDamage = enemyStats.finalDamage;


        // Update the health bar's value and text every frame
        PlayerHealthBar.maxValue = maxHealth;
        PlayerHealthBar.value = currentHealth;

        /* Update the health text */
        PlayerHealthText.text = string.Format("{0} / {1}", currentHealth, maxHealth);

        /* Update the player stats text */
        PlayerLevelText.text = $"Level: {currentLevel}";
        PlayerCurrentExpText.text = $"XP: {currentExp}";

        /* Update Strength in the UI*/
        PlayerStrengthText.text = $": {Strength}";

        /* Update Enemy stats */
        EnemyDamageText.text = $"Enemy D: {enemyDamage}";
        EnemyHealthText.text = $"Enemy HP: {enemyHealth}";
    }
}