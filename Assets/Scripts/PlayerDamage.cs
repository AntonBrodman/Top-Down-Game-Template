using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float damage;
    public Collider2D weaponCollider;
    public WeaponSO weapon;
    public Movement movement;
    private bool hit = false;


    void Start()
    {
        weaponCollider = GetComponent<Collider2D>();
        movement = GetComponentInParent<Movement>();
        damage = weapon.damage;
        print("damage: " + damage);
    }
    public void Setter()
    {
        
    }
    void Update()
    {
        if (!movement.isAttacking)
        {
            hit = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (movement.isAttacking && !hit)
        {
            hit = true;
            if (collision.CompareTag("Enemy"))
            {
                Health health = collision.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    print(damage + " hit");
                    health.TakeDamage(damage);
                }
            }
            else
            {
                // not an enemy
            }
        }
    }


}
