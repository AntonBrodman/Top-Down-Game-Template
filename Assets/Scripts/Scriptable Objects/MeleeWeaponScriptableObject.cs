using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Item/MeleeWeapon")]


public class MeleeWeaponScriptableObject : ScriptableObject
{
    public string Name;
    public float BaseDamage;
    public float Scaling;
    public int StaminaCost;
}
