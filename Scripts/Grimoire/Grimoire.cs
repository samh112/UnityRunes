using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grimoire", menuName = "Grimoire", order = 1)]
public class Grimoire : ScriptableObject
{
    public string elementName;
    public Sprite grimoireIcon;
    public bool isUnlocked;
}
