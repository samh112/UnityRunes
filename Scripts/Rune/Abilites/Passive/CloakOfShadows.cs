using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakOfShadows : MonoBehaviour
{
    private PlayerStateMachine player;
    private PlayerStatusEffects statusEffects;

    private float duration;
    private float cooldown;
    private float timer;
    private bool onCooldown = false;

    public void Initialize(float Duration, float Cooldown)
    {
        duration = Duration;
        cooldown = Cooldown;
    }

    private void Start()
    {
        player = PlayerStateMachine.instance;
        statusEffects = PlayerStatusEffects.instance;
    }

    private void Update()
    {
        if (player.IsRolling && !statusEffects.isCloaked && !onCooldown)
        {
            StartCoroutine(statusEffects.Cloak(duration));
            onCooldown = true;
        }

        if (onCooldown)
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                onCooldown = false;
                timer = 0;
            }
        }
    }
}
