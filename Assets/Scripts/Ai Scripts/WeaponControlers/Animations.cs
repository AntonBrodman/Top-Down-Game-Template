using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 4f;
    public float SpearRange = 6f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
