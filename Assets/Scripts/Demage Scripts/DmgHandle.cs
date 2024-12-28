using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHandle : MonoBehaviour
{
    public float damage;
    public Collider2D weaponCollider;
    public WeaponSO weapon;
    public Movement movement;
    private bool hit = false;


    void Start()
    {
        weaponCollider = GetComponentInChildren<Collider2D>();
        damage = weapon.damage;
        print("damage: " +damage);
    }
    void Update()
    {
        if (!movement.isAttacking)
        {
            hit = false;
        }
        //print("hit: " + hit + " || isAttacking: "+ !movement.isAttacking);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //print("entered" + movement.isAttacking + !hit);
        
        if (movement.isAttacking && !hit)
        {
            hit = true;
            print("boom");

            if (collision.CompareTag("Enemy"))
            {
                print("collision");
                Health health = collision.gameObject.GetComponent<Health>();
                //print(health);
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
