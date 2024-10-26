using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickUp : MonoBehaviour
{
    public Rune rune;

    private Loot loot;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        loot = GetComponent<Loot>();
    }

    private void Start()
    {
        sprite.sprite = rune.runeSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (loot.IsAcquireable() && collision.tag == "Player")
        {
            PlayerInventoryManager.instance.AddRune(rune);
            Destroy(this.gameObject);
        }
    }
}
