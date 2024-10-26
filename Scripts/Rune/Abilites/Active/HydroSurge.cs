using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroSurge : MonoBehaviour
{
    private float duration;
    private float damagePerSecond;
    private float pullForce;
    private float slowAmount;
    private List<StatusEffectsEnemy> enemiesInRange = new List<StatusEffectsEnemy>();

    public void Initialize(float duration, float damagePerSecond, float pullForce, float slowAmount)
    {
        this.duration = duration;
        this.damagePerSecond = damagePerSecond;
        this.pullForce = pullForce;
        this.slowAmount = slowAmount;

        StartCoroutine(VortexEffect());
        StartCoroutine(DealDamageOverTime());
    }

    private IEnumerator VortexEffect()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            foreach (StatusEffectsEnemy enemy in enemiesInRange)
            {
                if (enemy != null)
                {
                    Vector3 direction = (transform.position - enemy.transform.position).normalized;
                    enemy.GetComponent<Rigidbody2D>().AddForce(direction * pullForce);
                }
            }

            yield return null;
        }

        foreach (StatusEffectsEnemy enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                enemy.GetComponent<StatusEffectsEnemy>().RestoreSpeed();
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator DealDamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            foreach (StatusEffectsEnemy enemy in enemiesInRange)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<IDamageable>().Damage(damagePerSecond);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StatusEffectsEnemy enemy = other.GetComponent<StatusEffectsEnemy>();
        if (enemy != null)
        {
            enemiesInRange.Add(enemy);
            enemy.ReduceSpeed(slowAmount);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StatusEffectsEnemy enemy = other.GetComponent<StatusEffectsEnemy>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
            enemy.RestoreSpeed();
        }
    }
}
