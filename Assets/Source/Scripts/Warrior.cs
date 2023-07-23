using UnityEngine;

public abstract class Warrior : Unit, IAttack, ITakeDamage
{
    protected UnitInfo SelfInfo;

    public override void Init(UnitInfo unitInfo)
    {
        CurrentHealth = unitInfo.MaxHealth;
        SelfInfo = unitInfo;
    }

    public abstract void Attack();
    public abstract void TakeDamage(float damage);
}
