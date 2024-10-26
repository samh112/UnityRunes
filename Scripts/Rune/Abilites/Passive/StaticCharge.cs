using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCharge : MonoBehaviour
{
    public RuneAbilityStaticCharge staticChargeAbility;
    public PlayerStateMachine player;

    private void Start()
    {
        player = PlayerStateMachine.instance;
    }

    private void Update()
    {
        Debug.Log(staticChargeAbility.currentCharge);
        staticChargeAbility.UpdateCharge(gameObject);

        if (player.DidDamage)
        {
            staticChargeAbility.EmpowerAttack(gameObject);
            Debug.Log("reset");
        }
    }
}
