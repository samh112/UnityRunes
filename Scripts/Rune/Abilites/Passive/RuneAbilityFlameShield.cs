using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneFlameShieldAbility", menuName = "RuneAbility/Passive/FlameShield")]
public class RuneAbilityFlameShield : RuneAbility
{
    public float blockChance = 0.2f;
    public float fireDamage = 5f;

    public override void Activate(GameObject parent)
    {
        PlayerStatusEffects playerDefense = parent.GetComponent<PlayerStatusEffects>();
        if (playerDefense != null)
        {
            if (playerDefense.currentFlameShield != null)
            {
                playerDefense.RemoveFlameShield(playerDefense.currentFlameShield);
                //playerDefense.SetFlameShield(this);
            }

            else
            {
                //playerDefense.SetFlameShield(this);
            }
        }
    }

    public override void Deactivate(GameObject parent)
    {
        PlayerStatusEffects playerDefense = parent.GetComponent<PlayerStatusEffects>();
        if (playerDefense != null)
        {
            //playerDefense.RemoveFlameShield(this);
        }
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
