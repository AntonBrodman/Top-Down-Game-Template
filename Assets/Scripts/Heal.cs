using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float healDuration;
    public float healValue; // maybe put this into some scriptable object
    public float healMovementSpeed;



    public PlayerMovement playerMovement;


    //private Rigidbody2D rb;
    public bool isHealing;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

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
        //    rb.velocity = movement * healSpeed;


        yield return new WaitForSeconds(healDuration);
        PlayerHealth playerHealth = gameObject.GetComponent<PlayerHealth>();

        playerHealth.Heal(healValue);

        yield return new WaitForSeconds(healDuration);
        //playerMovement.moveSpeed = 3f;

        isHealing = false;
        //healCharges -= 1;
    }
}
