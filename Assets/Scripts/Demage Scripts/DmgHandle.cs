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
        weaponCollider = GetComponent<Collider2D>();
        damage = weapon.damage;

    }
    void Update()
    {
        if (!movement.isAttacking)
        {
            hit = false;
        }
        //print(movement.isAttacking);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //print("entered" + movement.isAttacking + !hit);
        print(collision.tag);

        if (movement.isAttacking && !hit)
        {
            hit = true;

            if (collision.CompareTag("Enemy"))
            {
                Health health = collision.gameObject.GetComponent<Health>();
                //print(health);
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
            else
            {
                print("Collided object is not tagged as Enemy.");
            }
        }
    }


}
