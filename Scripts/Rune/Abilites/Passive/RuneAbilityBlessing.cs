using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneBlessingAbility", menuName = "RuneAbility/Passive/Blessing")]
public class RuneAbilityBlessing : RuneAbility
{
    public float regenAmountHealth = 1f;
    public float regenAmountStamina = 1f;
    public float regenInterval = 5f;

    public override void Activate(GameObject parent)
    {
        PlayerStatusEffects.instance.StartCoroutine(PlayerStatusEffects.instance.Regenerate(regenAmountHealth, regenAmountStamina, regenInterval));
    }

    public override void Deactivate(GameObject parent)
    {
        PlayerStatusEffects.instance.regenerating = false;
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
