using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneSwiftAbility", menuName = "RuneAbility/Passive/Swift")]
public class RuneAbilitySwift : RuneAbility
{
    public float speedMultiplier = 1.5f;

    private void Awake()
    {
    }

    public override void Activate(GameObject parent)
    {
        var player = parent.GetComponent<PlayerStatusEffects>();
        if (player != null)
        {
            player.IncreaseMaxSpeed(speedMultiplier);
        }
    }

    public override void Deactivate(GameObject parent)
    {
        var player = parent.GetComponent<PlayerStatusEffects>();
        if ( player != null)
        {
            player.DecreaseMaxSpeed();
        }
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
