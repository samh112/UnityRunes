using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneIncinerateAbility", menuName = "RuneAbility/Attack/Incinerate")]
public class RuneAbilityIncinerate : RuneAbility
{
    public float duration = 5f;
    public float strength = 1.5f;

    public override void Activate(GameObject parent)
    {
        if (parent.GetComponent<IDamageable>() != null && parent.GetComponent<StatusEffectsEnemy>() != null)
        {
            var enemy = parent.GetComponent<IDamageable>();
            parent.GetComponent<MonoBehaviour>().StartCoroutine(parent.GetComponent<StatusEffectsEnemy>().Vulnerable(enemy, duration, strength));
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
