using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStorm : MonoBehaviour
{
    private PlayerStateMachine player;
    
    public float damagePerTick = 5f;

    private void Awake()
    {
        player = PlayerStateMachine.instance;
    }

    private void Update()
    {
        this.transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable enemy = collision.GetComponent<IDamageable>();
        if (enemy != null)
        {
            StartCoroutine(Burn(enemy));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamageable enemy = collision.GetComponent<IDamageable>();
        if (enemy != null)
        {
            StopCoroutine(Burn(enemy));
        }
    }

    private IEnumerator Burn(IDamageable enemy)
    {
        while (true)
        {
            enemy.Damage(damagePerTick);

            yield return new WaitForSeconds(1f);
        }
    }
}
