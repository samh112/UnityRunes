using UnityEngine;

[CreateAssetMenu(fileName = "RuneStaticChargeAbility", menuName = "RuneAbility/Passive/StaticCharge")]
public class RuneAbilityStaticCharge : RuneAbility
{
    private float _currentCharge = 0f;
    private Vector3 lastPosition;
    private bool _isCharged = false;
    private float storedDamage = 0f;
    private bool _stored = false;

    public float chargeRequirement = 100f;
    public float maxChargeDamage = 15f;
    public float currentCharge = 0f;
    public bool isCharged = false;

    private StaticCharge chargeScript;

    private void OnEnable()
    {
        currentCharge = _currentCharge;
        isCharged = _isCharged;
        _stored = false;
    }

    public override void Activate(GameObject parent)
    {
        lastPosition = parent.transform.position;
        chargeScript = parent.AddComponent<StaticCharge>();
        chargeScript.staticChargeAbility = this;
    }

    public override void Deactivate(GameObject parent)
    {
        currentCharge = 0f;
        isCharged = false;
        
        Destroy(chargeScript);
    }

    public void UpdateCharge(GameObject parent)
    {
        if (!(currentCharge >= chargeRequirement))
        {
            float movedDistance = Vector3.Distance(parent.transform.position, lastPosition);
            currentCharge += movedDistance;

            //if (currentCharge >= chargeRequirement)
            //{
            //    isCharged = true;
            //    currentCharge = 0f;
            //}

            lastPosition = parent.transform.position;
        }

        else if (!_stored)
        {
            storedDamage = parent.GetComponent<PlayerStateMachine>().WeaponDamage;
            parent.GetComponent<PlayerStateMachine>().WeaponDamage += maxChargeDamage;
            _stored = true;
            isCharged = true;
            Debug.Log("stored");
        }
    }

    public void EmpowerAttack(GameObject parent)
    {
        if (isCharged)
        {
            parent.GetComponent<PlayerStateMachine>().WeaponDamage = storedDamage;
            currentCharge = 0f;
            isCharged = false;
            _stored = false;
        }
    }

    public override void RetrieveInfo()
    {
        throw new System.NotImplementedException();
    }
}
