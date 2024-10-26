using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneShockWaveAbility", menuName = "RuneAbility/Attack/ShockWave")]
public class RuneAbilityShockWave : RuneAbility
{
    public float shockWaveRange = 2f;
    public float shockWaveDamage = 10f;
    public float shockwaveChance = 0.1f;
    public LayerMask enemyMask;

    public override void Activate(GameObject parent)
    {
        if (Random.value < shockwaveChance)
        {
            Collider2D[] colInfo = Physics2D.OverlapCircleAll(parent.GetComponentInChildren<EnemyCenterMass>().transform.position, shockWaveRange, enemyMask);
            foreach (Collider2D col in colInfo)
            {
                if (col.GetComponent<Enemy>() != null)
                {
                    var enemy = col.GetComponent<IDamageable>();
                    enemy.Damage(shockWaveDamage);
                }
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
