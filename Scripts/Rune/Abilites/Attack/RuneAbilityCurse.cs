using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneCurseAbility", menuName = "RuneAbility/Attack/Curse")]
public class RuneAbilityCurse : RuneAbility
{
    public float curseDuration = 5f;
    public float weakenMultiplied = 0.25f;

    public override void Activate(GameObject parent)
    {
        if (parent.CompareTag("Enemy"))
        {
            parent.GetComponent<StatusEffectsEnemy>().StartCoroutine(parent.GetComponent<StatusEffectsEnemy>().Weaken(curseDuration, weakenMultiplied));
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
