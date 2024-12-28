using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerStats PlayerStats;
    private Rigidbody2D Rigidbody2D;
    private PlayerStamina PlayerStamina;
    private Health PlayerHealth;
    private float walkSpeed;
    private float sprintSpeed;
    private float rollSpeed = 7f;
    private Vector2 movementDirection;
    private bool isRolling = false;
    public bool afterRoll = false;
    public bool isAttacking = false;
    private Animator Animator;
    private bool secondAttack = false;
    private bool action = false;
    void Start()
    {
        walkSpeed = PlayerStats.walkSpeed;
        sprintSpeed = PlayerStats.sprintSpeed;
        print(walkSpeed);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
        PlayerStamina = GetComponent<PlayerStamina>();
        PlayerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");
        
        // heal
        // interact

    }
    private void FixedUpdate()
    {
        if (action)
        {
            Rigidbody2D.velocity = movementDirection*0f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && !isRolling && !action)
        {
            Rigidbody2D.velocity = movementDirection * sprintSpeed;

        }
        else if(!isRolling && !action)
        {        
            Rigidbody2D.velocity = movementDirection * walkSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isRolling && !Input.GetKey(KeyCode.LeftShift) && !afterRoll && !secondAttack)
        {
            if (StaminaCheck())
            {
                PlayerStamina.StaminaDrain(30f);
                Animator.SetTrigger("S_1");
                StartCoroutine(Attack());
            }
            //print("attack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isRolling && !Input.GetKey(KeyCode.LeftShift) && !afterRoll && secondAttack)
        {
            if (StaminaCheck())
            {
                PlayerStamina.StaminaDrain(30f);
                Animator.SetTrigger("S_2");
                StartCoroutine(Attack());
            }
            //print("attack");
        }
        // s_2

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isRolling && !Input.GetKey(KeyCode.LeftShift) && afterRoll)
        {
            if (StaminaCheck())
            {
                PlayerStamina.StaminaDrain(30f);
                Animator.SetTrigger("S_R");
                StartCoroutine(Attack());
            }
            
            //print("attack");
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isRolling && Input.GetKey(KeyCode.LeftShift) && !afterRoll)
        {
            if (StaminaCheck())
            {
                PlayerStamina.StaminaDrain(30f);
                StartCoroutine(Dash());
            }
            Animator.SetTrigger("S_H");

        }
        if (Input.GetKeyDown(KeyCode.B) && movementDirection != Vector2.zero)
        {
            if (StaminaCheck())
            {
                PlayerStamina.StaminaDrain(30f);
                StartCoroutine(Dash());
            }

        }
        if (Input.GetKeyDown(KeyCode.R) && !isRolling)
        {
            // heal
        }


    }
    private IEnumerator Dash()
    {
        Vector2 rollDirection = movementDirection.normalized;
        Rigidbody2D.velocity = rollDirection * rollSpeed;
        isRolling = true;
        yield return new WaitForSeconds(0.25f);
        isRolling = false;
        afterRoll = true;
        yield return new WaitForSeconds(0.5f);
        afterRoll = false;


    }
    private IEnumerator Attack()
    {
        action = true;
        isAttacking = true;
        yield return new WaitForSeconds(0.75f);
        secondAttack = true;
        isAttacking = false;
        action = false;

        yield return new WaitForSeconds(0.75f);
        secondAttack = false;


    }
    public bool StaminaCheck()
    {
        return PlayerStamina.stamina > PlayerStamina.minStamina;
    }

}
