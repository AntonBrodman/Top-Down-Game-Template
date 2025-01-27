using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heal : Health
{

    public float healCharges = 7;
    public GameObject healChargesUiAmount;
    private void Start()
    {

    }
    public void RemoveHealCharge() {
        healCharges -= 1;
        
    }
    public IEnumerator HealAction()
    {
        yield return new WaitForSeconds(1f);
    }
}
