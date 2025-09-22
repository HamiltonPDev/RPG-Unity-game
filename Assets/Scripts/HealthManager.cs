using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int currentHealth;

    [Header ("IFrame stuff")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;

    [Header ("Exp when defeated")]
    public int expWhenDefeated;
    

    private Collider2D triggerCollider;
    private SpriteRenderer mySprite;

    void Start()
    {
        // Initialize current health with max health
        currentHealth = maxHealth;
        triggerCollider = GetComponent<Collider2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if health dropped to zero or below and deactivate the player object
        if (currentHealth <= 0)
        {
            /* If the object is an enemy, give experience to the player */
            if (gameObject.tag.Equals("Enemy"))
            {
                GameObject player = GameObject.Find("player");
                if (player != null)
                {
                    CharacterStats playerStats = player.GetComponent<CharacterStats>();
                    if (playerStats != null)
                    {
                        playerStats.AddExperience(expWhenDefeated);
                    }
                }
            }

            gameObject.SetActive(false); // Deactivate the player object
        }

    }

    /* Methods to calculate health damage */
    public void DamageCharacter(int damage)
    {
        StartCoroutine(FlashCo());
        currentHealth -= damage;
    }
    /* Method to update max health */
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth; // Reset current health to new max health
    }

    /* Coroutine to handle flashing effect */
    private IEnumerator FlashCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while (temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }
}