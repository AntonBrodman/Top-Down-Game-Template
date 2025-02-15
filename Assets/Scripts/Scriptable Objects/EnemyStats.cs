using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Stats/Enemy Stats")]

public class EnemyStats : EntityStats
{
    public float PhysicalRes;
    public float patrolSpeed;
    public float chaseSpeed;
    public float attackDistance;
}
