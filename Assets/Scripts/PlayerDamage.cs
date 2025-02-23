using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float totalDamage;
    public Collider2D weaponCollider;
    public MeleeWeaponScriptableObject weapon;

    public Movement movement;

    private bool hit = false;

    public PlayerLevels playerLevels;

    public float strenghtValue;



    void Start()
    {
        //strenghtValue = playerLevels.strenghtValue;
        weaponCollider = GetComponent<Collider2D>();
        movement = GetComponentInParent<Movement>();
        //totalDamage = weapon.BaseDamage + weapon.Scaling*strenghtValue;
        //Debug.Log(weapon.BaseDamage + " " + weapon.Scaling +" "+  strenghtValue);
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
                    print(totalDamage + " hit");
                    health.TakeDamage(totalDamage);
                }
            }
            else
            {
                // not an enemy
            }
        }
    }


}
