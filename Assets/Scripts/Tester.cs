using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Transform Player;
    private Transform testTransform;
    public float speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        print(mousePos);
        transform.position = mousePos;   
    }
}
