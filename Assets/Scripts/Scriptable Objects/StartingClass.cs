using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Class", menuName = "Item/Class")]

public class StartingClass : ScriptableObject
{
    public string Name;
    public int Health;
    public int Stamina;
    public int Strenght;
    public int Skill;
    public int Arcane;
}
