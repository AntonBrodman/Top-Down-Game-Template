//using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStamina : MonoBehaviour
{
    public Slider staminaSlider;
    public PlayerStats stats;
    [HideInInspector]
    public float maxStamina ;

    public float stamina;
    public float minStamina = 20f;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public float staminaGain = 2f;

    //public float staminaTimeout = 1f;
    private bool coroutineRunning;

    void Start()
    {
        maxStamina = stats.Stamina;
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (staminaSlider.value != stamina)
        {
            staminaSlider.value = stamina;
        }

        if (Time.time > nextActionTime)
        {
            //print(nextActionTime);
            nextActionTime += period;
            if (!coroutineRunning)
            {
                if (stamina < maxStamina)
                {
                    stamina += staminaGain;

                }
            }
        }
    }
    public void StaminaDrain(float staminaCost)
    {
        coroutineRunning = true;
        stamina -= staminaCost;
        if (stamina < 0)
        {
            stamina = 0;
        }
        StartCoroutine(StaminaCoroutine());
    }
    private IEnumerator StaminaCoroutine()
    {
        yield return new WaitForSeconds(1f);
        coroutineRunning = false;
    }
}
