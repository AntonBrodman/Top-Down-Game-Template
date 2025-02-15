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
        healthSlider.maxValue = entityStats.Health;
    }


    public override void Update()
    {
        base.Update();

        if (healAmountUi.text != healCharges.ToString())
        {
            healAmountUi.text = healCharges.ToString();
        }
    }


    public void PlayerHealValue()
    {
        if(healCharges > 0)
        {
            Heal(healAmount);
            healCharges--;
        }
    }
}
