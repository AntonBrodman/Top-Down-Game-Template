using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerStats PlayerStats;
    private Rigidbody2D Rigidbody2D;
    private Stamina PlayerStamina;
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
    public bool canInteract = false;
    public ItemHolder itemHolder;
    public Item item;
    void Start()
    {
        walkSpeed = PlayerStats.walkSpeed;
        sprintSpeed = PlayerStats.sprintSpeed;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
        PlayerStamina = GetComponent<Stamina>();
        PlayerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        if (action)
        {

            Rigidbody2D.velocity = movementDirection*0f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && !isRolling && !action)
        {
            PlayerStamina.drainStamina = true;
            Rigidbody2D.velocity = movementDirection * sprintSpeed;

        }

        else if(!isRolling && !action && !Input.GetKey(KeyCode.LeftShift))
        {
            PlayerStamina.drainStamina = false;
            Rigidbody2D.velocity = movementDirection * walkSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isRolling && !Input.GetKey(KeyCode.LeftShift) && !afterRoll && !secondAttack)
        {
            if (StaminaCheck())
            {
                PlayerStamina.ConsumeStamina(30f);
                Animator.SetTrigger("S_1");
                StartCoroutine(Attack());
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isRolling && !Input.GetKey(KeyCode.LeftShift) && afterRoll)
        {
            if (StaminaCheck())
            {
                PlayerStamina.ConsumeStamina(30f);
                Animator.SetTrigger("S_R");
                StartCoroutine(Attack());
            }
            
            //print("attack");
        }
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //itemHolder.AddItem();
                itemHolder.AddItem(item.itemContext);
                item.Destoy();
                //Destroy(item);
                //print("picked up: " + item.itemContext);

            }
        }
        if (Input.GetKeyDown(KeyCode.B) && movementDirection != Vector2.zero)
        {
            if (StaminaCheck())
            {
                PlayerStamina.ConsumeStamina(30f);
                StartCoroutine(Dash());
            }

        }
        if (Input.GetKeyDown(KeyCode.R) && !isRolling)
        {
            PlayerHealth.Heal(80f);
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
        return PlayerStamina.currentStamina > PlayerStamina.minStamina;
    }

}
