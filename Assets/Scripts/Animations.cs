using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 4f;
    public float SpearRange = 6f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance < SpearRange && distance > AttackRange)
        {
            animator.SetTrigger("stab");

        }
        else if (distance < AttackRange)
        {
            animator.SetTrigger("inRange");

        }
        else
        {
            return;
        }

    }
}
