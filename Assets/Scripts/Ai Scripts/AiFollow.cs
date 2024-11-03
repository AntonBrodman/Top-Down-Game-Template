using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditorInternal;

public class AiFollow : MonoBehaviour
{
    public EnemyStats stats;
    private Transform Player;  // Changed from public to private
    //[HideInInspector]
    public float EnemySpeed;
    public float AttackRange = 2f;
    public float SwordRange = 4f;
    public float SpearRange = 6f;
    public Animator animator;
    public float stateDuration = 1f;
    public AttackCollision attackCollision;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        EnemySpeed = stats.patrolSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null) return;  // Ensure Player is found before continuing
        Patrol();
        //float distance = Vector2.Distance(transform.position, Player.position);

        //if (distance < AttackRange)
        //{
        //    Passive();
        //}
        //else
        //{
        //    ChaseTarget();
        //}

        //if (distance > AttackRange)
        //{
        //    ChaseTarget();
        //}
        //else
        //{
        //    animator.SetTrigger("Swipe");
        //}
    }
    void Combat()
    {

    }
    void ChaseTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, EnemySpeed * Time.deltaTime);
    }

    void Passive() // running from palayer
    {
        
        Vector2 directionToPlayer = Player.position - transform.position;
        Vector2 moveDirection = -directionToPlayer.normalized;
        transform.Translate(moveDirection * EnemySpeed * Time.deltaTime);
    }
    void Patrol() // from point to point repeating
    {
        if (waypoints.Length == 0) return;
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, EnemySpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
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
