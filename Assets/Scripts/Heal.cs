using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heal : MonoBehaviour
{

    public Health healthScript;
    public PlayerStats stats;
    public PlayerMovement playerMovement;
    [HideInInspector]

    public bool isHealing;
    [HideInInspector]
    public float healDuration;
    [HideInInspector]
    public float healValue = 40f;
    [HideInInspector]
    public float healMovementSpeed;
    private void Start()
    {
        healDuration = stats.healDuration;
        healValue = stats.healValue;
        healMovementSpeed = stats.healMovementSpeed;
    }
    public void StartHealCoroutine() {
        StartCoroutine(HealAction());
    }
    public IEnumerator HealAction()
    {
        isHealing = true;
        //playerMovement.movement = playerMovement.movement * healMovementSpeed; // 3 1
        //playerMovement.moveSpeed = healMovementSpeed;

        //playerMovement.rb.velocity = playerMovement.movement * healMovementSpeed;
        //rb.velocity = movement * healSpeed;


        yield return new WaitForSeconds(healDuration);
        //Health playerHealth = gameObject.GetComponent<Health>();

        healthScript.health += healValue;
        if(healthScript.health >= healthScript.entityStats.Health)
        {
            healthScript.health = healthScript.entityStats.Health;
        }
        //print(healthScript.health);

        //playerHealth.Heal(healValue);

        yield return new WaitForSeconds(healDuration);
        //playerMovement.moveSpeed = 3f;

        isHealing = false;
        //healCharges -= 1;
    }
}
