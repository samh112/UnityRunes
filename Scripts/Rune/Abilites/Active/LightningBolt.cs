using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    private float damage;
    private float radius;
    private float duration;

    public void Initialize(float Damage, float Radius, float Duraiton)
    {
        damage = Damage;
        radius = Radius;
        duration = Duraiton;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            IDamageable enemy = collision.GetComponent<IDamageable>();
            enemy.Damage(damage);

            collision.GetComponent<StatusEffectsEnemy>().Stunned(duration);
        }
    }

    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
