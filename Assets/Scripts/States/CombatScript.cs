using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{

    public Animator animator;
    public void Combat()
    {
        StartCoroutine(State());
        
    }

    public  IEnumerator State()
    {
        int randomNumber = Random.Range(1, 3);
        Debug.Log(randomNumber);
        if(randomNumber == 1)
        {
            animator.SetTrigger("Swipe");
        }
        
        yield return new WaitForSeconds(1f);
        
    }

}
