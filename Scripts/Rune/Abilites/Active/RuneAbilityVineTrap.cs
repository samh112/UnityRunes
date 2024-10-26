using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "RuneVineTrapAbility", menuName = "RuneAbility/Active/VineTrap")]
public class RuneAbilityVineTrap : RuneAbility
{
    public GameObject vineTrap;
    public float radius = 2f;
    public float damage = 10f;
    public float duration = 5f;
    public float coolDown = 15f;

    private float lastActivationTime = -Mathf.Infinity;

    private void OnEnable()
    {
        lastActivationTime = -Mathf.Infinity;
    }

    public override void Activate(GameObject parent)
    {
        if (Time.time >= lastActivationTime + coolDown)
        {
            var spawnedVineTrap = Instantiate(vineTrap, parent.transform.position, vineTrap.transform.rotation);
            spawnedVineTrap.GetComponent<VineTrap>().Initialize(radius, damage, duration);

            Destroy(spawnedVineTrap, duration);
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
