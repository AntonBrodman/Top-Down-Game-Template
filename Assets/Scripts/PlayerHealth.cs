using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStatistics stats;
    public Slider healthSlider;
    public float maxHealth = 500f;
    public float health;
    public float healCharges;

    void Start()
    {
        health = stats.Health;
        //health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
       
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            print("Died");
        }
    }
    public void Heal(float heal)
    {
        if (health >= maxHealth)
        {
            return;
        }
        else
        {
            health += heal;
            if (health > maxHealth)
            {
                health = maxHealth;
            }

        }

        //    if (health >= maxHealth)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        health += 200;
        //        if (health > maxHealth)
        //        {
        //            health = maxHealth;
        //        }
        //    }
    }
}
