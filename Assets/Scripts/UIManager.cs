using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    // References to UI elements
    public Slider PlayerHealthBar;
    public Text PlayerHealthText;

    // Reference to the player's HealthManager script
    public HealthManager playerHealthManager;

    void Update()
    {
        int maxHealth = playerHealthManager.maxHealth;
        int currentHealth = playerHealthManager.currentHealth;

        // If we level up and max health changes, update the health bar's max value

        // Update the health bar's value and text every frame
        PlayerHealthBar.maxValue = maxHealth;
        PlayerHealthBar.value = currentHealth;

        /* Update the health text */
        PlayerHealthText.text = string.Format("{0} / {1}", currentHealth, maxHealth);
    }
}
