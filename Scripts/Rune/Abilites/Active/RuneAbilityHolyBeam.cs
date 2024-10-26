using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneHolyBeamAbility", menuName = "RuneAbility/Active/HolyBeam")]
public class RuneAbilityHolyBeam : RuneAbility
{
    public GameObject HolyBeam;
    public float duration = 2f;
    public float initialDamage = 30f;
    public float tickDamage = 0.5f;
    public float range = 20f;

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
            GameObject spawnedHolyBeam = null;
            var player = parent.GetComponent<PlayerStateMachine>();

            if (!player.FacingLeft)
            {
                spawnedHolyBeam = Instantiate(HolyBeam, new Vector3(player.transform.position.x + range / 2 + 1f, player.transform.position.y + 1.12f, player.transform.position.z), parent.transform.rotation);
            }

            else
            {
               spawnedHolyBeam = Instantiate(HolyBeam, new Vector3(player.transform.position.x - range / 2 - 1f, player.transform.position.y + 1.12f, player.transform.position.z), parent.transform.rotation);
            }

            spawnedHolyBeam.GetComponent<HolyBeam>().Initialize(initialDamage, tickDamage, duration, range);

            Destroy(spawnedHolyBeam, duration);
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
