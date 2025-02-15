using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFlaskRefill : MonoBehaviour
{
    public Collider2D collider2d;
    //public GameObject ui;
    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ui.SetActive(true);
        playerHealth.healCharges = 20;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //ui.SetActive(false);

    }
}
