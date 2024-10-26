using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    private float damage;
    private float duration;
    private float pullStrength;
    private float speed;
    private List<StatusEffectsEnemy> enemiesInRange = new List<StatusEffectsEnemy>();

    public void Initialize(float Damage, float Duration, float Speed, float PullStrength)
    {
        damage = Damage;
        duration = Duration;
        speed = Speed;
        pullStrength = PullStrength;

        StartCoroutine(TornadoEffect());
        StartCoroutine(DealDamageOverTime());
    }

    private void Start()
    {
        if (PlayerStateMachine.instance.FacingLeft)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed * -1f, 0f);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0f);
        }
    }

    private IEnumerator TornadoEffect()
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
                    enemy.GetComponent<Rigidbody2D>().AddForce(direction * pullStrength);
                }
            }

            yield return null;
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
                    enemy.GetComponent<IDamageable>().Damage(damage);
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StatusEffectsEnemy enemy = other.GetComponent<StatusEffectsEnemy>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
        }
    }
}
