using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneWaveAbility", menuName = "RuneAbility/Active/Wave")]
public class RuneAbilityWave : RuneAbility
{
    public GameObject wave;
    public float waveDuration = 3f;
    public float waveSpeed = 3f;

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
                var spawnedWave = Instantiate(wave, new Vector3(player.transform.position.x, player.transform.position.y - 0.82f, player.transform.position.z), wave.transform.rotation);

                if (PlayerStateMachine.instance.FacingLeft)
                {
                    spawnedWave.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(waveSpeed * -1f, 0f);
                }
                else
                {
                    spawnedWave.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(waveSpeed, 0f);
                }

                Destroy(spawnedWave, waveDuration);
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
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
