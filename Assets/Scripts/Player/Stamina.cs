//using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Stamina : MonoBehaviour
{
    public Slider staminaSlider;
    public PlayerStats stats;
    [HideInInspector]
    public float maxStamina;
    public float currentStamina;
    public float minStamina = 20f;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public float staminaGain = 2f;
    public float staminaDrainValue;

    //public float staminaTimeout = 1f;
    private bool coroutineRunning;

    public bool drainStamina;

    void Start()
    {
        //GameObject.Find(“aname”).GetComponent();


        maxStamina = stats.Stamina;
        currentStamina = maxStamina;
    }

    void Update()
    {
        if (staminaSlider.value != currentStamina)
        {
            staminaSlider.value = currentStamina;
        }

        StaminaRegeneration(drainStamina);
        StaminaDrain(drainStamina);
    }
    public void StaminaRegeneration(bool drainStamina)//continuous stamina regeneration
    {
        if(drainStamina == false)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                if (!coroutineRunning)
                {
                    if (currentStamina < maxStamina)
                    {
                        currentStamina += staminaGain;

                    }
                }
            }
        }

    }
    public void StaminaDrain(bool drainStamina)//continuous stamina drain
    {
        if (drainStamina)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                if (!coroutineRunning)
                {
                    if (currentStamina != 0)
                    {

                        currentStamina -= staminaDrainValue;

                    }
                }
            }
        }
    }
    public void ConsumeStamina(float staminaCost)
    {
        coroutineRunning = true;
        currentStamina -= staminaCost;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
        StartCoroutine(StaminaCoroutine());
    }
   
    private IEnumerator StaminaCoroutine()
    {

        yield return new WaitForSeconds(0.5f);
        coroutineRunning = false;
    }
}
