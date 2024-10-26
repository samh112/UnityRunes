using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoirePickUp : MonoBehaviour
{
    public Grimoire grimoire;

    private PlayerInventoryManager playerGrimoireData;
    private SpriteRenderer sprite;
    private Loot loot;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        loot = GetComponent<Loot>();
    }

    private void Start()
    {
        playerGrimoireData = PlayerInventoryManager.instance;
        sprite.sprite = grimoire.grimoireIcon;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerGrimoireData.UnlockGrimoire(grimoire);
            // Show some UI feedback
            Destroy(gameObject);
        }
    }
}

