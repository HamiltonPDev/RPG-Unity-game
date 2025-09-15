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
            // Apply damage to the player
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            var clone = Instantiate(
                damageNumberPrefab, collision.transform.position,
                Quaternion.Euler(Vector3.zero) // no rotation
            );
            // set the damage amount on the damage number
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
