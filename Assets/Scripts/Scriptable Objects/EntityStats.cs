using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Stats", menuName = "Stats/Entity Stats")]

public class EntityStats : ScriptableObject
{
    public string EntityName;
    public float Health;
}
