using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public Animator weaponPointAnimator;
    public GameObject weaponAnimationPoint;
    public ItemHolder itemHolder;
    public Item item;

    private Rigidbody2D Rigidbody2D;
    private Stamina PlayerStamina;
    private Animator playerAnimator;
    private PlayerHealth PlayerHealth;

    private float walkSpeed;
    private float sprintSpeed;
    private float rollSpeed = 7f;
    private Vector2 movementDirection;
    private bool isRolling = false;
    private bool action = false;

    public float slow;
    public bool afterRoll = false;
    public bool isAttacking = false;
    public bool canInteract = false;
    public bool isHealing = false;

    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector
    public Transform firePoint; // Assign a child GameObject that represents the fire point
    public float projectileSpeed = 10f;
    
    void Start()
    {
        walkSpeed = PlayerStats.walkSpeed;
        sprintSpeed = PlayerStats.sprintSpeed;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        weaponAnimationPoint = GameObject.Find("AnimationPoint");
        weaponPointAnimator = weaponAnimationPoint.GetComponentInChildren<Animator>();
        PlayerStamina = GetComponent<Stamina>();
        PlayerHealth = GetComponent<PlayerHealth>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        if(movementDirection.x > 0)
        {
            //Debug.Log("right");
            //transform.localScale = new Vector3(1, 1, 1); // Facing right


        }
        else if(movementDirection.x < 0)
        {
            //Debug.Log("left");
            //transform.localScale = new Vector3(-1, 1, 1); // Facing left


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

        else if (isHealing)
        {
            Rigidbody2D.velocity = movementDirection * slow;

        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && !action && !afterRoll) 

        {
            if (StaminaCheck())
            {
                PlayerStamina.ConsumeStamina(15f);
                weaponPointAnimator.SetTrigger("S_1");
                StartCoroutine(Attack(0.5f));
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !action && !afterRoll)

        {
            //Debug.Log("fire");
            StartCoroutine(FireCooldown());
            //if (StaminaCheck())
            //{
            //    PlayerStamina.ConsumeStamina(30f);
            //    weaponPointAnimator.SetTrigger("S_1");
            //    StartCoroutine(Attack(0.5f));
            //}
        }

        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                itemHolder.AddItem(item.itemContext);
                item.Destoy();
                PlayerHealth.healCharges = 20;


            }
        }
        if (Input.GetKeyDown(KeyCode.B) && movementDirection != Vector2.zero && !action) //roll
        {
            if (StaminaCheck())
            {
                PlayerStamina.ConsumeStamina(30f);
                StartCoroutine(Dash());
            }

        }
        if (Input.GetKeyDown(KeyCode.R) && !isRolling && !isHealing && !action) //heal
        {
            StartCoroutine(HealCoroutine());
        }

        // input conditions and their actions
    }
    private IEnumerator Dash()
    {
        action = true;
        Vector2 rollDirection = movementDirection.normalized;
        Rigidbody2D.velocity = rollDirection * rollSpeed;
        isRolling = true;
        yield return new WaitForSeconds(0.2f);
        action = false;
        isRolling = false;
        afterRoll = true;
        yield return new WaitForSeconds(1f);
        afterRoll = false;

    }
    private IEnumerator Attack(float duration)
    {
        action = true;
        isAttacking = true;
        yield return new WaitForSeconds(duration);
        isAttacking = false;
        action = false;
    }
    private IEnumerator HealCoroutine()
    {
        playerAnimator.SetTrigger("HealTrigger");
        action = true;
        isHealing = true;
        yield return new WaitForSeconds(1f);
        PlayerHealth.PlayerHealValue();
        isHealing = false; 
        action = false;
    }
    public bool StaminaCheck()
    {
        return PlayerStamina.currentStamina > PlayerStamina.minStamina;
    }
    void Fire()
    {
        // Instantiate the projectile with 180-degree rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 180));
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Use firePoint.up instead of firePoint.right to correctly fire in the intended direction
            rb.velocity = -firePoint.up * projectileSpeed; // Moves correctly in the expected leftward direction
            Debug.Log(rb.velocity);
        }

        Destroy(projectile, 2f); // Destroy bullet after 3 seconds
    }
    private IEnumerator FireCooldown()
    {

        action = true;
        isAttacking = true;
        Fire();
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        action = false;
    }



}
