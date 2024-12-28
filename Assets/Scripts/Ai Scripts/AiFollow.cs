using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    public EnemyStats stats;
    private Transform Player;  // Changed from public to private
    //[HideInInspector]
    public float patrolSpeed;
    public float chaseSpeed;
    public float AttackRange = 2f;
    public float SwordRange = 4f;
    public float SpearRange = 6f;
    public Animator animator;
    public float stateDuration = 1f;
    public AttackCollision attackCollision;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Rigidbody2D Rigidbody2D;
    //private bool hasLineOfSight = false;
    public enum states{Patrol, Chase, Passive, Search, Combat };


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        patrolSpeed = stats.patrolSpeed;
        chaseSpeed = stats.chaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null) return;  // Ensure Player is found before continuing
        float distance = Vector2.Distance(transform.position, Player.position);

        Chase();
    }
    void StateManager(states s)
    {

        //switch(s)
    }
    void Combat()
    {

    }
    void Chase()
    {

        Vector2 direction = (Player.position - transform.position).normalized;
        Rigidbody2D.velocity = direction * patrolSpeed;
    }

    void Idle()
    {

    }
     // keeping distance from palayer
    void Passive()
    {
        
        Vector2 directionToPlayer = Player.position - transform.position;
        Vector2 moveDirection = -directionToPlayer.normalized;
        transform.Translate(moveDirection * (patrolSpeed * 0.5f) * Time.deltaTime);
    }
    void Patrol() // from point to point repeating
    {
        Passive();
        if (waypoints.Length == 0) return;
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, patrolSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
    void Search()
    {

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
