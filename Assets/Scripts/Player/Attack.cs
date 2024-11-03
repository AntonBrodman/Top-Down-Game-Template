using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isAttacking;
    private Animator WeaponAnimator;
    public WeaponSO weapons;
    public PlayerStamina stamina;
    public float weaponStamCost;
    public GameObject weapon;
    private Collider2D weaponCollider;

    // Start is called before the first frame update
    void Start()
    {
        WeaponAnimator = GetComponentInChildren<Animator>();
        weaponStamCost = weapons.staminaCost;
        weaponCollider = weapon.GetComponent<Collider2D>();
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAttackCoroutine()
    {
        StartCoroutine(AttackAction());
    }
    private IEnumerator AttackAction()
    {
        //print("stop");

        isAttacking = true;
        //rb.velocity = movement * 0f;
        weaponCollider.enabled = true;

        switch (weapons.weaponType)
        {
            case "sword":
                WeaponAnimator.SetTrigger("swordAttack");

                break;
            case "spear":
                WeaponAnimator.SetTrigger("spearAttack");
                break;
        }
        yield return new WaitForSeconds(weapons.attackSpeed/2); // split because of issues with animator and animations

        WeaponAnimator.SetTrigger("idle");

        yield return new WaitForSeconds(weapons.attackSpeed/2);
        weaponCollider.enabled = false;

        isAttacking = false;

    }

}
