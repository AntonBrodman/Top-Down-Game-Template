using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerLevels : MonoBehaviour
{
    public string activeClassName;
    public int healthLevel;
    public int maxHealth;
    public int staminaLevel;
    public int maxStamina;
    public int strenghtLevel;
    public int strenghtValue;
    public int skillLevel;
    public int skillValue;
    public int arcaneLevel;
    public int arcaneValue;

    public StartingClass[] startingClasses;
    public PlayerHealth playerHealth;

    //[SerializeField]
    public StatsValues stats;
    void Start()
    {
        activeClassName = RenderStartingClasses.selectedClass;
        switch (RenderStartingClasses.selectedClass)
        {
            case "Lost One":
                healthLevel = startingClasses[0].Health;
                staminaLevel = startingClasses[0].Stamina;
                strenghtLevel = startingClasses[0].Strenght;
                skillLevel = startingClasses[0].Skill;
                arcaneLevel = startingClasses[0].Arcane;
                break;
            case "Brute":
                healthLevel = startingClasses[1].Health;
                staminaLevel = startingClasses[1].Stamina;
                strenghtLevel = startingClasses[1].Strenght;
                skillLevel = startingClasses[1].Skill;
                arcaneLevel = startingClasses[1].Arcane;
                break;
            case "Doctor":
                healthLevel = startingClasses[2].Health;
                staminaLevel = startingClasses[2].Stamina;
                strenghtLevel = startingClasses[2].Strenght;
                skillLevel = startingClasses[2].Skill;
                arcaneLevel = startingClasses[2].Arcane;
                break;
            case "Noble":
                healthLevel = startingClasses[3].Health;
                staminaLevel = startingClasses[3].Stamina;
                strenghtLevel = startingClasses[3].Strenght;
                skillLevel = startingClasses[3].Skill;
                arcaneLevel = startingClasses[3].Arcane;
                break;
            case "Veteran":
                healthLevel = startingClasses[4].Health;
                staminaLevel = startingClasses[4].Stamina;
                strenghtLevel = startingClasses[4].Strenght;
                skillLevel = startingClasses[4].Skill;
                arcaneLevel = startingClasses[4].Arcane;
                break;
            case "Mad One":
                healthLevel = startingClasses[5].Health;
                staminaLevel = startingClasses[5].Stamina;
                strenghtLevel = startingClasses[5].Strenght;
                skillLevel = startingClasses[5].Skill;
                arcaneLevel = startingClasses[5].Arcane;
                break;
        }
        if (healthLevel < 1)
        {
            healthLevel = 1;
        }
        else if(healthLevel > 26)
        {
            healthLevel = 26;
        }
        maxHealth = CalculateMaxHealth(healthLevel, stats.healthValues);
        Debug.Log(maxHealth);
        playerHealth.health = maxHealth;
        playerHealth.healthSlider.maxValue = maxHealth;
        maxStamina = CalculateMaxHealth(staminaLevel, stats.staminaValues);
        Debug.Log(maxStamina);

        strenghtValue = CalculateMaxHealth(strenghtLevel, stats.strenghtValues);
        Debug.Log(strenghtValue);

        skillValue = CalculateMaxHealth(skillLevel, stats.skillValues);
        Debug.Log(skillValue);

        arcaneValue = CalculateMaxHealth(arcaneLevel, stats.arcaneValues);
        Debug.Log(arcaneValue);



    }


    public int CalculateMaxHealth(int levelValue, int[] array)
    {
        //if (levelValue < 1 || levelValue > array.Length)
        //{
        //    Debug.LogError("Level value is out of range!");
        //    return 0; // Return a default value to prevent errors
        //}

        Debug.Log(array[levelValue - 1]); // Debugging
        return array[levelValue - 1]; // Return the correct health value
    }

}
