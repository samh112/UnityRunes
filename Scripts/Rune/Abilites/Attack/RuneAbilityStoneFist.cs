using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuneStoneFistAbility", menuName = "RuneAbility/Attack/StoneFist")]
public class RuneAbilityStoneFist : RuneAbility
{
    public float damageMultiplier = 0.5f;
    public float knockbackForce = 10f;

    public override void Activate(GameObject parent)
    {
        var rB = parent.GetComponent<Rigidbody2D>();
        Vector3 direction = (- PlayerStateMachine.instance.transform.position + parent.transform.position).normalized;

        rB.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        parent.GetComponent<IDamageable>()?.Damage(PlayerStateMachine.instance.WeaponDamage * damageMultiplier);
    }

    public override void Deactivate(GameObject parent)
    {
        throw new System.NotImplementedException();
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
