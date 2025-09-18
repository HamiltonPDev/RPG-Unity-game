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

    void Start()
    {
        playerWeaponDamage = FindFirstObjectByType<WeaponDamage>();
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


        // Update the health bar's value and text every frame
        PlayerHealthBar.maxValue = maxHealth;
        PlayerHealthBar.value = currentHealth;

        /* Update the health text */
        PlayerHealthText.text = string.Format("{0} / {1}", currentHealth, maxHealth);

        /* Update the player stats text */
        PlayerLevelText.text = "Level: " + currentLevel.ToString();
        PlayerCurrentExpText.text = "XP: " + currentExp.ToString();

        /* Update Strength in the UI*/
        PlayerStrengthText.text = "Strength: " + Strength.ToString();
    }
}