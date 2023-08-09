using System;
using UnityEngine;

public class Warrior : Unit, IAttack, ITakeDamage
{
    [SerializeField] private UnitInfo _selfInfo;

    private float _currentHealth;
    private Player _target;

    public override float CurrentHealth => _currentHealth;
    public override UnitInfo SelfInfo => _selfInfo;
    public override Type SelfType => typeof(Warrior);
    public override Player Target => _target;

    public override event Action<Unit> Dead;

    public void Attack()
    {
        _target.TakeDamage(SelfInfo.Damage);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 1)
            return;

        _currentHealth -= damage;

        HealthChanged();
    }

    public override void Init(Player player)
    {
        _target = player;
    }

    private void HealthChanged()
    {
        if (CurrentHealth <= 0)
            Dead?.Invoke(this);
    }
}
