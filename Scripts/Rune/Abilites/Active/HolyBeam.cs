using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBeam : MonoBehaviour
{
    private float initialDamage;
    private float tickDamage;
    private float duration;
    private float range;

    private BoxCollider2D boxCollider;

    public void Initialize(float InitialDamage, float TickDamage, float Duration, float Range)
    {
        initialDamage = InitialDamage;
        tickDamage = TickDamage;
        duration = Duration;
        range = Range;

        boxCollider = GetComponent<BoxCollider2D>();
        PlayerStateMachine.instance.CanMove = false;

        var transform = GetComponent<Transform>();
        transform.localScale = new Vector3(range, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            collision.GetComponent<IDamageable>().Damage(initialDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            collision.GetComponent<IDamageable>().Damage(tickDamage);
            new WaitForSeconds(0.5f);
        }
    }

    private void OnDestroy()
    {
        PlayerStateMachine.instance.CanMove = true;
    }
}
