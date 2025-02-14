using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : Health
{
    public int healCharges;
    public int healAmount;
    public TextMeshProUGUI healAmountUi;
    void Start()
    {
        healAmountUi.text = healCharges.ToString();
        //health = entityStats.Health;
        healthSlider.maxValue = entityStats.Health;
    }

    //public override void Update()
    //{
    //    base.Update();
    //}
    
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
