using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackStart;
    public float attackDuration;
    public float demage;
    public AttackTiming attackInfo;
    private Collider2D weaponCollider;
    public GameObject weapon;
    public bool attacking;
    //public GameObject weapon;
    void Start()
    {
        attackStart = attackInfo.attackStart;
        attackDuration = attackInfo.attackDuration;
        demage = attackInfo.damage;
        weaponCollider = weapon.GetComponent<Collider2D>();  
        //weaponCollider.enabled = false;
        print(weaponCollider);
    }


    public IEnumerator Attack()
    {
        attacking = true;
        yield return new WaitForSeconds(attackStart);
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(attackDuration);
        weaponCollider.enabled = false;
        attacking = false;
    }
}
