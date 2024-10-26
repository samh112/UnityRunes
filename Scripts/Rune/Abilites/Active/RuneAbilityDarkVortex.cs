using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneDarkVortexAbility", menuName = "RuneAbility/Active/DarkVortex")]
public class RuneAbilityDarkVortex : RuneAbility
{
    public GameObject vortex;
    public float pullForce = 10f;
    public float pullRadius = 5f;
    public float tickDamage = 1f;
    public float tickRate = 0.5f;
    public float coolDown = 10f;
    public float duration = 5f;

    public float lastActivationTime = -Mathf.Infinity;

    private void OnEnable()
    {
        lastActivationTime = -Mathf.Infinity;
    }

    public override void Activate(GameObject parent)
    {
        if (Time.time >= lastActivationTime + coolDown)
        {
            var spawnedVOrtex = Instantiate(vortex, parent.transform.position, vortex.transform.rotation);
            spawnedVOrtex.GetComponent<DarkVortex>().Initialize(pullForce, pullRadius, tickDamage, tickRate, duration);

            lastActivationTime = Time.time;
            Destroy(spawnedVOrtex, duration);
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
