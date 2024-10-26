using UnityEngine;
using System.Collections.Generic;

public class TidalSlash : MonoBehaviour
{
    public float damage = 10f;
    public float force = 50f;

    private HashSet<GameObject> damagedEnemies = new HashSet<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<IDamageable>();
        if (enemy != null && !damagedEnemies.Contains(collision.gameObject))
        {
            enemy.Damage(damage);
            damagedEnemies.Add(collision.gameObject);

            // Apply push back
            var enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    Vector2 pushDirection = (collision.transform.position - player.transform.position).normalized;
                    enemyRigidbody.AddForce(force * pushDirection, ForceMode2D.Impulse);
                }
                else
                {
                    Debug.LogError("Player not found when calculating push direction.");
                }
            }
        }
    }
}
