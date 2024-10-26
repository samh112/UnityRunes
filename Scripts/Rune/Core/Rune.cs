using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewRune", menuName = "Rune")]
public class Rune : ScriptableObject
{
    public string runeName;
    public Sprite runeSprite;
    public string abilityDescription;
    public RuneAbility runeAbility;
    public string element;
    public Sprite icon;

    public bool isAttackRune = false, isPassiveRune = false, isActiveRune = false;

    public string RetrieveInfo()
    {
        return runeName + "\n-" + abilityDescription;
    }
}
