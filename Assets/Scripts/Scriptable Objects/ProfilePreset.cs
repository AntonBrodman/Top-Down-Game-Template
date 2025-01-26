using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Presets", menuName = "Stats/Player Presets")]

public class ProfilePreset : ScriptableObject
{
    public string PresetName;
    public int health;
    public int stamina;
    public int strength;
    
}
