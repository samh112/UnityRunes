using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneFortifyAbility", menuName = "RuneAbility/Passive/Fortify")]
public class RuneAbilityFortify : RuneAbility
{
    public float damageReduction = 0.5f;

    public override void Activate(GameObject parent)
    {
        PlayerStatusEffects.instance.IncreaseDamageResistance(damageReduction);
    }

    public override void Deactivate(GameObject parent)
    {
        PlayerStatusEffects.instance.DecreaseDamageResistance(damageReduction);
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
