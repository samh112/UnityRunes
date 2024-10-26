using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkVortex : MonoBehaviour
{
    private float pullForce;
    private float pullRadius;
    private float tickDamage;
    private float tickRate;
    private float duration;

    private List<Enemy> affectedEnemies = new List<Enemy>();

    public void Initialize(float PullForce, float PullRadius, float TickDamage, float TickRate, float Duration)
    {
        pullForce = PullForce;
        pullRadius = PullRadius;
        tickDamage = TickDamage;
        tickRate = TickRate;
        duration = Duration;

        transform.localScale = new Vector3(pullRadius, pullRadius, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Enemy>();
            if (enemy != null && !affectedEnemies.Contains(enemy))
            {
                affectedEnemies.Add(enemy);
                StartCoroutine(PullEnemy(enemy));
                StartCoroutine(DamageEnemy(enemy));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Enemy>();
            if (enemy != null && affectedEnemies.Contains(enemy))
            {
                affectedEnemies.Remove(enemy);
            }
        }
    }

    private IEnumerator PullEnemy(Enemy enemy)
    {
        while (affectedEnemies.Contains(enemy))
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)enemy.transform.position;
            enemy.GetComponent<Rigidbody2D>().AddForce(direction.normalized * pullForce * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator DamageEnemy(Enemy enemy)
    {
        while (affectedEnemies.Contains(enemy))
        {
            enemy.Damage(tickDamage);
            yield return new WaitForSeconds(tickRate);
        }
    }
}
