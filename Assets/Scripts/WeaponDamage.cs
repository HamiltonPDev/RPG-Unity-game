using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    /* Damage amount */
    public int damage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            // this line applies damage to the enemy
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            // this ine creates a visual effect at the hit location
            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);
        }
    }
}
