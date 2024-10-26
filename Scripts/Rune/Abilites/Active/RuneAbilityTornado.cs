using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneTornadoAbility", menuName = "RuneAbility/Active/Tornado")]
public class RuneAbilityTornado : RuneAbility
{
    public GameObject tornado;
    public float tornadoDamage = 5f;
    public float tornadoDuration = 5f;
    public float tornadoSpeed = 5f;
    public float tornadoPullStrength = 20f;

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
            var spawnedTornado = Instantiate(tornado, new Vector3(parent.transform.position.x, parent.transform.position.y + 1, parent.transform.position.z), tornado.transform.rotation);

            spawnedTornado.GetComponent<Tornado>().Initialize(tornadoDamage, tornadoDuration, tornadoSpeed, tornadoPullStrength);

            Destroy(spawnedTornado, tornadoDuration);

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
