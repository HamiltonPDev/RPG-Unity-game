using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    /* Damage amount */
    public int damage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber;
    private GameObject currentEnemy; // track current enemy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            // Reset damege if attacking a different enemy
            if (currentEnemy != collision.gameObject)
            {
                DamageNumber.ResetDamage();
                currentEnemy = collision.gameObject;
            }
            // this line applies damage to the enemy
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            // this line creates a visual effect at the hit location
            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);

            // this line creates a damage number at the hit location
            var clone = Instantiate(
                damageNumber, hitPoint.transform.position,
                Quaternion.Euler(Vector3.zero) // no rotation
            );
            // set the damage amount on the damage numberdama
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
