using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerInput;

public class Attack : MonoBehaviour
{
    public bool isAttacking;
    private Animator WeaponAnimator;
    //public WeaponSO weapons;
    public PlayerStamina stamina;
    public float weaponStamCost;
    public GameObject weapon;
    private Collider2D weaponCollider;
    public bool recovering = false;
    //public float recovery = 0.3f; // lerp duration
    public ItemHolder items;
    private float S_1_D;
    private float S_1_R;
    private float S_2_D;
    private float S_2_R;
    //private float opening = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //print(items.activeWeapon);
        //S_1_D = items.activeWeapon.S_1_D;
        //S_1_R = items.activeWeapon.S_1_R;
        //S_2_D = items.activeWeapon.S_2_D;
        //S_2_R = items.activeWeapon.S_2_R;
        WeaponAnimator = GetComponentInChildren<Animator>();
        //weaponStamCost = weapons.staminaCost;
        weaponCollider = weapon.GetComponent<Collider2D>();
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAttackCoroutine(PlayerInput.AttackType attackType)
    {
        StartCoroutine(AttackAction(attackType));
    }
    private IEnumerator AttackAction(PlayerInput.AttackType attackType)
    {
        WeaponAnimator.SetBool("idle", false);

        if (!isAttacking)
        {
            //switch (attackType)
            //{
            //    case AttackType.S_1:
            //        WeaponAnimator.SetTrigger("S_1");

            //        break;

            //    case AttackType.S_2:
            //        WeaponAnimator.SetTrigger("S_2");

            //        break;
            //    case AttackType.S_H:
            //        WeaponAnimator.SetTrigger("S_H");

            //        break;

            //    case AttackType.S_R:
            //        WeaponAnimator.SetTrigger("S_R");

            //        break;
            //}
        }
        //print(S_1_R);
        isAttacking = true;
        //rb.velocity = movement * 0f;
        weaponCollider.enabled = true;

        yield return new WaitForSeconds(0.05f);
        recovering = true;
        weaponCollider.enabled = false;
        //print("can follow up");
  

        yield return new WaitForSeconds(0.05f);
        //print("end of attack");

        recovering = false;
        isAttacking = false;
        //yield return new WaitForSeconds(opening);
        WeaponAnimator.SetBool("idle", true);


    }

}
