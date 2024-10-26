using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneRadianceAbility", menuName = "RuneAbility/Attack/Radiance")]
public class RuneAbilityRadiance : RuneAbility
{
    public float blindDuration = 10f;
    public float burnDuration = 10f;
    public float burnDamage = 1f;

    public override void Activate(GameObject parent)
    {
        var effects = parent.GetComponent<StatusEffectsEnemy>();
        if (effects != null)
        {
            effects.StartCoroutine(effects.Blind(blindDuration));
            effects.StartCoroutine(effects.Burn(parent.GetComponent<IDamageable>(), burnDuration, burnDamage, 1f));
        }
    }

    public override void Deactivate(GameObject parent)
    {
        throw new System.NotImplementedException();
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
