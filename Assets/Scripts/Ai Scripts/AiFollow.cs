using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class AiFollow : MonoBehaviour
{
    public Transform Player;
    public float EnemySpeed = 5f;
    public float AttackRange = 2f;
    public float SwordRange = 4f;
    public float SpearRange = 6f;
    public Animator animator;
    public float stateDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomNuber());
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        if(distance < AttackRange)
        {
            Passive();

        }
        else
        {
            ChaseTarget();
        }
        //print(distance);
        if (distance > AttackRange) // pokud vzdalenost od hrá?e je v?tší jak vzdalenost útoku
        {
            ChaseTarget();
            if (distance < SpearRange && distance > SwordRange)
            {

                animator.SetTrigger("Stab");
            }
            else if (distance < SwordRange)
            {

                animator.SetTrigger("Swipe");
            }
        }
        else
        {
            if (distance < SpearRange && distance > SwordRange)
            {

                animator.SetTrigger("Stab");
            }
            else if (distance < SwordRange)
            {

                animator.SetTrigger("Swipe");
            }
        }
    }
    void ChaseTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, EnemySpeed * Time.deltaTime);

    }
    void Passive()
    {
        Vector2 directionToPlayer = Player.position - transform.position;

        // Calculate the direction to move away from the player
        Vector2 moveDirection = -directionToPlayer.normalized;

        // Move the enemy in the opposite direction of the player
        transform.Translate(moveDirection * EnemySpeed * Time.deltaTime);
    }
    private IEnumerator RandomNuber()
    {

        while (true)
        {


            int randomNumber = UnityEngine.Random.Range(1, 4);
            Debug.Log(randomNumber);
            yield return new WaitForSeconds(stateDuration);
            yield return randomNumber;
        }



    }
}
