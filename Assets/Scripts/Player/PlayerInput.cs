using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using static PlayerInput;

public class PlayerInput : MonoBehaviour
    
{
    //public Heal playerHeal;
    public Attack attack;
    //public PlayerMovement playerMovement;
    public PlayerStamina stamina;
    public Heal heal;


    public float healCharges;
    public TextMeshProUGUI healAmount;

    public enum AttackType
    {
        S_1,
        S_2,
        S_H,
        S_R
    }
    public AttackType attakcType;

    void Start()
    {
        healAmount.text = healCharges.ToString();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(healCharges > 0)
            {
                heal.StartHealCoroutine();
                healCharges -= 1;
                healAmount.text = healCharges.ToString();
            }
            else
            {
                print("no heal charges left");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftShift))
        {
            //print("light");
            if (stamina.stamina > stamina.minStamina)   //stamina check
            {
                if (stamina != null)
                {
                    stamina.StaminaDrain(attack.weaponStamCost);
                }
                if (attack.recovering)
                {
                    //print(attack.recovering);
                    //print("should be S2");
                    attakcType = AttackType.S_2;

                }
                else
                {
                    //print(attakcType);
                    //print(attack.recovering);

                    attakcType = AttackType.S_1;

                }
            }
            else
            {
                return;
            }
            
            //print(attack.canChain);
            attack.StartAttackCoroutine(attakcType);
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftShift))
        {
            //print(attakcType);
            //print(attack.canChain);
            if (stamina.stamina > stamina.minStamina)   //stamina check
            {
                if (stamina != null)
                {
                    stamina.StaminaDrain(attack.weaponStamCost);
                }

            }
            else
            {
                return;
            }
            attakcType = AttackType.S_H;
            //if (attack.canChain)
            //{
            //    print(attakcType);

            //}
            //else
            //{
            //    print(attakcType);

            //    attakcType = AttackType.S_1;

            //}
            //print(attack.canChain);
            attack.StartAttackCoroutine(attakcType);
        }
    }

}
