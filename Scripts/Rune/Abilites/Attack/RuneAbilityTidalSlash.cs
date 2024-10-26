using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneTidalSlashAbility", menuName = "RuneAbility/Attack/TidalSlash")]
public class RuneAbilityTidalSlash : RuneAbility
{
    public GameObject TidalSlash;
    public float tidalSlashChance = 0.1f;
    public float tidalSlashDamage = 10f;
    public float tidalSlashDuration = 0.5f;
    public float tidalSlashSpeed = 5f;
    public float tidalSlashForce = 50f;

    public override void Activate(GameObject parent)
    {
        if (Random.value < tidalSlashChance)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                var spawnedWave = Instantiate(TidalSlash, new Vector3(player.transform.position.x, player.transform.position.y - 0.82f, player.transform.position.z), TidalSlash.transform.rotation);
                spawnedWave.GetComponent<TidalSlash>().damage = tidalSlashDamage;
                spawnedWave.GetComponent<TidalSlash>().force = tidalSlashForce;

                if (PlayerStateMachine.instance.FacingLeft)
                {
                    spawnedWave.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(tidalSlashSpeed * -1f, 0f);
                }
                else
                {
                    spawnedWave.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(tidalSlashSpeed, 0f);
                }

                Destroy(spawnedWave, tidalSlashDuration);
            }
            else
            {
                Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
            }
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
