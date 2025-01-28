using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private Collider2D damageArea;
        private bool canDamage = true; // Flag to control damage timing

    public PlayerHealth playerHealth;
    public float damageCooldown = 1f;

    public int damage;
    void Start()
    {
        damageArea = GetComponent<Collider2D>();
        print("gg");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage)
        {
            print("player Entered");
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            StartCoroutine(DamageCooldown());

        }
    }
    private IEnumerator DamageCooldown()
    {
        canDamage = false; // Prevent further damage
        yield return new WaitForSeconds(damageCooldown); // Wait for cooldown
        canDamage = true; // Allow damage again
    }


}
