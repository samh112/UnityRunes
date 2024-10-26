using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneThornsAbility", menuName = "RuneAbility/Attack/Thorns")]
public class RuneAbilityThorns : RuneAbility
{
    public float thornDamage = 2f;
    public float thornDamageRate = 0.5f;
    public float thornDuration = 5f;
    public float entangleDuration = 2f;

    public override void Activate(GameObject parent)
    {
        if (parent.CompareTag("Enemy"))
        {
            parent.GetComponent<StatusEffectsEnemy>().StartCoroutine(parent.GetComponent<StatusEffectsEnemy>().ThornLogic(thornDamage, thornDamageRate, thornDuration, entangleDuration));
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
