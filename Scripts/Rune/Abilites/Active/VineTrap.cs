using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTrap : MonoBehaviour
{
    private Enemy enemy;
    private float radius;
    private float damage;
    private float duration;

    public void Initialize(float Radius, float Damage, float Duration)
    {
        radius = Radius;
        damage = Damage;
        duration = Duration;

        transform.localScale = new Vector3(radius, 0.2f, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            enemy = collision.GetComponent<Enemy>();
            var newDamage = PlayerElementalModifiers.instance.ElementalLogic(PlayerStateMachine.instance.gameObject, enemy. gameObject, damage, PlayerElementalModifiers.ElementalType.nature);
            enemy.GetComponent<IDamageable>().Damage(newDamage);
            enemy.rB.linearVelocity = Vector2.zero;
            enemy.GetComponent<StatusEffectsEnemy>().StartCoroutine(enemy.GetComponent<StatusEffectsEnemy>().Entangle(duration));
        }
    }

    private void OnDestroy()
    {
        if (enemy != null)
        { 
            enemy.canMove = true;
        }
    }
}
