using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHandle : MonoBehaviour
{
    public float damage;
    public Collider2D weaponCollider;
    public AttackTiming timing;



    void Start()
    {
        weaponCollider = GetComponentInChildren<Collider2D>();
        damage = timing.damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");

        Health health = collision.gameObject.GetComponent<Health>();
        print(health);
        if (health != null)
        {
            health.TakeDamage(damage);
        }

    }
}
