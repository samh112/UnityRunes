using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneWindArmorAbility", menuName = "RuneAbility/Passive/WindArmor")]
public class RuneAbilityWindArmor : RuneAbility
{
    public float blockChance = 0.4f;
    public float blockAmount = 0.35f;

    public override void Activate(GameObject parent)
    {
        PlayerStatusEffects playerDefense = parent.GetComponent<PlayerStatusEffects>();
        if (playerDefense != null)
        {
            if (playerDefense.currentWindArmor != null)
            {
                playerDefense.RemoveWindArmor(playerDefense.currentWindArmor);
                playerDefense.SetWindArmor(this);
            }

            else
            {
                playerDefense.SetWindArmor(this);
            }
        }
    }

    public override void Deactivate(GameObject parent)
    {
        PlayerStatusEffects playerDefense = parent.GetComponent<PlayerStatusEffects>();
        if (playerDefense != null)
        {
            playerDefense.RemoveWindArmor(this);
        }
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
