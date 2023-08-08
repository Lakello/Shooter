using System;

public abstract class Warrior : Unit, IAttack, ITakeDamage
{
    public override void Init(UnitInfo unitInfo)
    {
        CurrentHealth = unitInfo.MaxHealth;
        SelfInfo = unitInfo;
    }

    public abstract void Attack();
    public abstract void TakeDamage(float damage);
}
