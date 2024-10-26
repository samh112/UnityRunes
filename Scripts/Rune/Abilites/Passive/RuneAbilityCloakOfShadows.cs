using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneCloakOfShadowsAbility", menuName = "RuneAbility/Passive/CloakOfShadows")]
public class RuneAbilityCloakOfShadows : RuneAbility
{
    private CloakOfShadows cloak;

    public float duration = 12f;
    public float cooldown = 30f;

    public override void Activate(GameObject parent)
    {
        cloak = parent.AddComponent<CloakOfShadows>();
        cloak.Initialize(duration, cooldown);
    }

    public override void Deactivate(GameObject parent)
    {
        Destroy(cloak);
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
