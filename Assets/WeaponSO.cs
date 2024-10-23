using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]

public class WeaponSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public float demage;
    public float staminaCost;
    public float attackSpeed;
    public string weaponType;

    //public bool isEquided;
    //public bool isOwned;
}
