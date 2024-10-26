using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneBurnAbility", menuName = "RuneAbility/Attack/Burn")]
public class RuneBurnAbility : RuneAbility
{
    public float burnDuration = 5f;
    public float burnDamagePerTick = 2f;
    public float burnTickInterval = 1f;

    public override void Activate(GameObject parent)
    {
        var enemy = parent.GetComponent<StatusEffectsEnemy>();
        if (enemy != null)
        {
            enemy.StartCoroutine(enemy.Burn(enemy.gameObject.GetComponent<IDamageable>(), burnDuration, burnDamagePerTick, burnTickInterval));
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
