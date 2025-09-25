using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    public GameObject damageNumberPrefab;

    /* OnCollisionEnter2D is for detecting player collisions */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Damage the player */
        if (collision.gameObject.tag.Equals("Player"))
        {
            /* Defense levels player */
            CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>();
            int totalDamage = damage - stats.defenseLevels[stats.currentLevel];
            if (totalDamage < 0) totalDamage = 0; // Prevent negative damage
            // Apply damage to the player
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);

            var clone = Instantiate(
                damageNumberPrefab, collision.transform.position,
                Quaternion.Euler(Vector3.zero) // no rotation
            );
            // set the damage amount on the damage number
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }

    /* Method to update damage dynamically */
    public void UpdateDamage(int newDamage)
    {
        damage = newDamage;
    }
}
