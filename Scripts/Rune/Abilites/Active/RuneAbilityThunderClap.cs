using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneThunderClapAbility", menuName = "RuneAbility/Active/ThunderClap")]
public class RuneAbilityThunderClap : RuneAbility
{
    public GameObject lightningBolt;
    public float boltDamage = 20f;
    public float boltRadius = 2f;
    public float stunDuration = 5f;
    public float coolDown = 10f;

    private float lastActivationTime = -Mathf.Infinity;

    private void OnEnable()
    {
        lastActivationTime = -Mathf.Infinity;
    }

    public override void Activate(GameObject parent)
    {
        if (Time.time >= lastActivationTime + coolDown)
        {
            var spawnedBolt = Instantiate(lightningBolt, new Vector3(parent.transform.position.x, parent.transform.position.y + 2.1326f, parent.transform.position.z), lightningBolt.transform.rotation);

            spawnedBolt.GetComponent<LightningBolt>().Initialize(boltDamage, boltRadius, stunDuration);

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
