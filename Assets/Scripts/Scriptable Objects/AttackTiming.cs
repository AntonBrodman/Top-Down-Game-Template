using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack Timing", menuName = "Stats/Attack Timing")]

public class AttackTiming : ScriptableObject
{
    public string attackName;
    public float attackStart;
    public float attackDuration;
    public float damage;
}
