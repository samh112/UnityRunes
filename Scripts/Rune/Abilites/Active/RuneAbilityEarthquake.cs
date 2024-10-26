using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneEarthquakeAbility", menuName = "RuneAbility/Active/Earthquake")]
public class RuneAbilityEarthquake : RuneAbility
{
    public float quakeDuration = 1f;
    public float quakeRange = 3f;
    public float quakeDamage = 10f;
    public float stunDuration = 2f;

    private Transform player;
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
            player = parent.transform;

            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(player.position, new Vector2(quakeRange, quakeRange), 0);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    var statusEffects = enemy.GetComponent<StatusEffectsEnemy>();
                    var damageable = enemy.GetComponent<IDamageable>();
                    var groundCheck = enemy.GetComponent<Ground>();

                    if (groundCheck != null && groundCheck.OnGround && statusEffects != null && damageable != null)
                    {
                        statusEffects.StartCoroutine(statusEffects.Stunned(stunDuration));
                        damageable.Damage(quakeDamage);
                    }
                }
            }

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

    private void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(player.position, new Vector3(quakeRange, quakeRange, 0));
        }
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
