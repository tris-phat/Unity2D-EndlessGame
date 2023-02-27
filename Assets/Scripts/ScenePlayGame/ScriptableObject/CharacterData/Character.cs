using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObject/New Character")]
public class Character : ScriptableObject
{
    public Sprite imageCharacter; 
    public string Name;
    public int ID;
    public int Price;

    public bool isUnlocked;
}
