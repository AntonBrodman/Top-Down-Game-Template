using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerStats PlayerStats;
    private Rigidbody2D Rigidbody2D;
    private float walkSpeed;
    private float sprintSpeed;
    private float rollSpeed = 7f;
    private Vector2 movementDirection;
    private bool isRolling = false;
    void Start()
    {
        walkSpeed = PlayerStats.walkSpeed;
        sprintSpeed = PlayerStats.sprintSpeed;
        print(walkSpeed);
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        print(movementDirection.x);
        movementDirection.y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.B) && movementDirection != Vector2.zero)
        {
            print("roll");
            StartCoroutine(Dash());
        }
        // heal
        // attacks
        // interact

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isRolling)
        {
            Rigidbody2D.velocity = movementDirection * sprintSpeed;

        }
        else if(!isRolling)
        {        
            Rigidbody2D.velocity = movementDirection * walkSpeed;
        }

    }
    private IEnumerator Dash()
    {
        Vector2 rollDirection = movementDirection.normalized;
        Rigidbody2D.velocity = rollDirection * rollSpeed;
        isRolling = true;
        yield return new WaitForSeconds(0.25f);
        isRolling = false;
    }
}
