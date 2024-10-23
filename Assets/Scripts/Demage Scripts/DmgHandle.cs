using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHandle : MonoBehaviour
{
    public float dmg = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");
        //PlayerHealth health
        //PlayerHealth health
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(dmg);
        }

    }
}
