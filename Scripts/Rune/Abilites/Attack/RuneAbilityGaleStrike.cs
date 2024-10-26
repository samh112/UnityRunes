using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneGaleStrikeAbility", menuName = "RuneAbility/Attack/GaleStrike")]
public class RuneAbilityGaleStrike : RuneAbility
{
    public GameObject gust;
    public float gustChance = 0.2f;
    public float gustSpeed = 5f;
    public float gustDuration = 3f;

    public override void Activate(GameObject parent)
    {
        if (Random.value < gustChance)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                var spawnedWave = Instantiate(gust, new Vector3(player.transform.position.x, player.transform.position.y - 0.82f, player.transform.position.z), gust.transform.rotation);

                if (PlayerStateMachine.instance.FacingLeft)
                {
                    spawnedWave.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gustSpeed * -1f, 0f);
                }
                else
                {
                    spawnedWave.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gustSpeed, 0f);
                }

                Destroy(spawnedWave, gustDuration);
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
