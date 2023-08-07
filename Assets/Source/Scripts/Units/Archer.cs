public abstract class Archer : Unit, IAttack, ITakeDamage
{
    protected UnitInfo _selfInfo;

    public override void Init(UnitInfo unitInfo)
    {
        CurrentHealth = unitInfo.MaxHealth;
        _selfInfo = unitInfo;
    }

    public abstract void Attack();
    public abstract void TakeDamage(float damage);
}
