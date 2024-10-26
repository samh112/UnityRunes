using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneRegrowthAbility", menuName = "RuneAbility/Passive/Regrowth")]
public class RuneAbilityRegrowth : RuneAbility
{
    public float lifeStealPercentage = 0.2f;

    public override void Activate(GameObject parent)
    {
        PlayerElementalModifiers.instance.HealthSteal[PlayerElementalModifiers.ElementalType.nature] += lifeStealPercentage;
    }

    public override void Deactivate(GameObject parent)
    {
        PlayerElementalModifiers.instance.HealthSteal[PlayerElementalModifiers.ElementalType.nature] -= lifeStealPercentage;
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
