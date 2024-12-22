using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float healDuration = 1f;
    public float dashCooldown = 1f;
    public float rollCost = 30f;
    //public float minStamina = 20f;
    public float healValue = 40f;
    public float healSpeed = 2f;
    public float healCharges = 7;
    //public GameObject WeaponAnimator;
    public WeaponSO weapons;
    public Heal heal;
    public Attack attack;


    public Rigidbody2D rb;
    private Animator PlayerAnimator;
    private Animator WeaponAnimator;
    private Collider2D Collider;
    private SpriteRenderer SpriteRenderer;
    public Vector2 movement;
    private bool isDashing = false;
    private bool isHealing = false;
    private bool canDash = true;
    public PlayerStamina stamina;


    private bool facingLeft = true;

    Color rollColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        WeaponAnimator = GetComponentInChildren<Animator>();
        //PlayerStamina stamina = gameObject.GetComponent<PlayerStamina>();

// pass animation to child
        Collider = GetComponent<Collider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0; // Ensure z position is zero for 2D space

        Vector3 direction = cursorPosition - transform.position;

        if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            // global moveSpeed ;D ?????

            if (!facingLeft)
            {
                moveSpeed = 2f;
            }
            else
            {
                moveSpeed = 3f;

            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            //PlayerAnimator.SetTrigger("RollRight");
            //print("walking right ::: facing left = " + facingLeft);
            if (facingLeft)
            {
                moveSpeed = 2f;
            }
            else
            {
                moveSpeed = 3f;
            }
        }
        if (direction.x < 0)
        {
            facingLeft = true;

        }
        else
        {
            facingLeft = false;
        }

        //if (Input.GetKeyDown(KeyCode.R) && !isHealing && healCharges > 0)
        //{
        //    StartCoroutine(HealAction());
        //    PlayerAnimator.SetTrigger("healTrigger");
        //}

        if (Input.GetKeyDown(KeyCode.B) && canDash && !isHealing)
        {
            //PlayerStamina stamina = gameObject.GetComponent<PlayerStamina>();

            if (stamina.stamina > stamina.minStamina)
            {
                if (stamina != null)
                {
                    stamina.StaminaDrain(rollCost);
                }

            }
            else
            {
                return;
            }

            StartCoroutine(Dash());

            if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                //PlayerAnimator.SetTrigger("RollLeft");

            }
            else if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                //PlayerAnimator.SetTrigger("RollRight");

            }
            else
            {
                //PlayerAnimator.SetTrigger("RollRight");
            }
        }

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{

        //    StartCoroutine(Attack());
        //}
    }

    void FixedUpdate()
    {
        if (!isDashing && !heal.isHealing && !attack.isAttacking)
        {
            rb.velocity = movement * moveSpeed;
            //Heal.healMovementSpeed
            
        }
        else if (heal.isHealing)
        {
            
            rb.velocity = movement * heal.healMovementSpeed;
        }
        else if (attack.isAttacking)
        {
            rb.velocity = movement * 0f;
            //print("stop");
        }
       // rb.velocity = movement * moveSpeed;
        
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        if (SpriteRenderer != null)
        {
            SpriteRenderer.color = rollColor;
        }
        else
        {
            //print("no renderer");
        }

        Collider.enabled = false;
        rb.velocity = movement * dashSpeed;

        yield return new WaitForSeconds(dashDuration);
        Collider.enabled = true;

        if (SpriteRenderer != null)
        {
            SpriteRenderer.color = Color.white;
        }

        rb.velocity = Vector2.zero;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    //private IEnumerator HealAction()
    //{
    //    isHealing = true;
    //    rb.velocity = movement * healSpeed;

    //    yield return new WaitForSeconds(healDuration);
    //    PlayerHealth playerHealth = gameObject.GetComponent<PlayerHealth>();
    //    playerHealth.Heal(healValue);
    //    print("heal");

    //    yield return new WaitForSeconds(healDuration);
    //    isHealing = false;
    //    healCharges -= 1;
    //}
    //private IEnumerator Attack()
    //{
    //    isHealing = true;
    //    rb.velocity = movement * 0f;
        
    //    yield return new WaitForSeconds(weapons.attackSpeed);

    //    switch (weapons.weaponType)
    //    {
    //        case "sword":
    //            WeaponAnimator.SetTrigger("swordAttack");

    //            break;
    //        case "spear":
    //            WeaponAnimator.SetTrigger("spearAttack");
    //            break;
    //    }
    //    yield return new WaitForSeconds(weapons.attackSpeed);

    //    WeaponAnimator.SetTrigger("idle");
    //    isHealing = false;

    //}
}
