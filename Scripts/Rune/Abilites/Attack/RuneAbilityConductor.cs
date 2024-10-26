using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneConductorAbility", menuName = "RuneAbility/Attack/Conductor")]
public class RuneAbilityConductor : RuneAbility
{
    public GameObject lightningBoltPrefab;
    public float lightningBoltDuration = .5f;

    public float lightningDamage = 5f;
    public int spreadCount = 3;

    private float spreadRadius = 3f;
    public LayerMask enemyMask;

    public override void Activate(GameObject parent)
    {
        if (parent.GetComponent<IDamageable>() != null)
        {
            parent.GetComponent<MonoBehaviour>().StartCoroutine(parent.GetComponent<StatusEffectsEnemy>().Shock(parent.GetComponent<Enemy>(), lightningDamage));
            parent.GetComponent<MonoBehaviour>().StartCoroutine(SpreadLightning(parent, spreadCount));
        }
    }

    public IEnumerator SpreadLightning(GameObject parent, int RemainingChains)
    {
        if (RemainingChains > 0)
        {
            Collider2D[] colInfo = Physics2D.OverlapCircleAll(parent.GetComponent<Transform>().position, spreadRadius, enemyMask);
            foreach (Collider2D col in colInfo)
            {
                if ((col.GetComponent<IDamageable>() != null) && (col.gameObject != parent.gameObject))
                {
                    var enemy = col.GetComponent<IDamageable>();
                    if (!col.gameObject.GetComponent<StatusEffectsEnemy>().shocked)
                    {
                        if (lightningBoltPrefab != null)
                        {
                            GameObject lightningBolt = Instantiate(lightningBoltPrefab, (parent.GetComponentInChildren<EnemyCenterMass>().transform.position + col.GetComponentInChildren<EnemyCenterMass>().transform.position) / 2, Quaternion.identity);
                            Destroy(lightningBolt, lightningBoltDuration);
                        }

                        col.GetComponent<MonoBehaviour>().StartCoroutine(col.GetComponent<StatusEffectsEnemy>().Shock(enemy, lightningDamage));

                        yield return new WaitForSeconds(0.5f);
                        yield return SpreadLightning(col.gameObject, RemainingChains - 1);
                    }
                }
            }
        }

        else yield return null;
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
