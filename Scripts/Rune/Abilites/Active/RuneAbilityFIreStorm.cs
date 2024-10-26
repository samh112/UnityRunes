using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneFireStormAbility", menuName = "RuneAbility/Active/FireStorm")]
public class RuneAbilityFireStorm : RuneAbility
{
    public GameObject fireStorm;
    public float stormDuration = 5f;
    public float fireDamage = 5f;

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
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                var spawnedFireStorm = Instantiate(fireStorm, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), fireStorm.transform.rotation);
                spawnedFireStorm.GetComponent<FireStorm>().damagePerTick = fireDamage;

                Destroy(spawnedFireStorm, stormDuration);
                lastActivationTime = Time.time;
            }
            else
            {
                Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
            }
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
