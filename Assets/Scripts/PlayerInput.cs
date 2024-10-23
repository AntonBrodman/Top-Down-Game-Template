using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class PlayerInput : MonoBehaviour
    
{
    //public Heal playerHeal;
    public Attack attack;
    public PlayerMovement playerMovement;
    public PlayerStamina stamina;
    public Heal heal;


    public float healCharges;
    public TextMeshProUGUI healAmount;


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
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (stamina.stamina > stamina.minStamina)
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
            attack.StartAttackCoroutine();
        }
    }
}
