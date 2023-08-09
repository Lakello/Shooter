using System;
using UnityEngine;

public class Warrior : Unit, IAttack, ITakeDamage
{
    [SerializeField] private UnitInfo _selfInfo;

    private float _currentHealth;

    public override float CurrentHealth => _currentHealth;
    public override UnitInfo SelfInfo => _selfInfo;
    public override Type SelfType => typeof(Warrior);

    public override event Action<Unit> Dead;

    public void Attack()
    {
        //target.TakeDamage(SelfInfo.Damage);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 1)
            return;

        _currentHealth -= damage;

        HealthChanged();
    }

    private void HealthChanged()
    {
        if (CurrentHealth <= 0)
            Dead?.Invoke(this);
    }
}
