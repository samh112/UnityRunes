using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneHydroSurgeAbility", menuName = "RuneAbility/Active/HydroSurge")]
public class RuneAbilityHydroSurge : RuneAbility
{
    public GameObject hydroSurge;
    public float vortexDuration = 5f;
    public float damagePerSecond = 10f;
    public float pullForce = 5f;
    public float slowAmount = 0.5f;

    private float coolDown = 10f;
    private float lastActivationTime = -Mathf.Infinity;

    private void OnEnable()
    {
        lastActivationTime = -Mathf.Infinity;
    }

    public override void Activate(GameObject parent)
    {
        if (Time.time >= lastActivationTime + coolDown)
        {
            var spawnedHydroSurge = Instantiate(hydroSurge, parent.transform.position, Quaternion.identity);

            spawnedHydroSurge.GetComponent<HydroSurge>().Initialize(vortexDuration, damagePerSecond, pullForce, slowAmount);

            lastActivationTime = Time.time;
        }

        else
        {
            Debug.Log("Ability is on cooldown.");
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
