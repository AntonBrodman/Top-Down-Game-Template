using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFlaskRefill : MonoBehaviour
{
    public Collider2D collider2d;
    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.healCharges = 20;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
