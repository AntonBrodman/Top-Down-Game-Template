using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : Health
{
    public int healCharges;
    public int healAmount;
    public TextMeshProUGUI healAmountUi;
    void Start()
    {
        healAmountUi.text = healCharges.ToString();
    }

    void Update()
    {
        
    }
    public void PlayerHealValue()
    {
        if(healCharges > 0)
        {
            Heal(healAmount);
            healCharges--;
            healAmountUi.text = healCharges.ToString();
        }


    }
}
