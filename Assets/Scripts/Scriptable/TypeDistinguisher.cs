using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LiquidDarkness/" + nameof(TypeDistinguisher))]
public class TypeDistinguisher : ScriptableObject
{
    public string PrefsKey => name;
    public PlayerPrefType prefType;
    public bool purgable = true;

    public enum PlayerPrefType
    {
        INT, 
        FLOAT, 
        STRING,
        STORY
    }
}
