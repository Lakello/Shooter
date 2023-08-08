using UnityEngine;
using Zenject;

public class EnemyWarrior : Warrior, ITickable
{
    private Player _target;

    private void Awake()
    {
        _target = GameObject.FindFirstObjectByType<Player>();
    }

    public void Tick()
    {
        var distance = Vector3.Distance(transform.position,
                                        _target.transform.position);

        if (SelfInfo == null)
            Debug.Log("Âñ¸ õóéíÿ");

        if (distance > SelfInfo.AttackDistance)
        {
            Move();
        }
        else
        {
            Attack();
        }
    }

    public override void Attack()
    {
        _target.TakeDamage(SelfInfo.Damage);
    }

    public override void TakeDamage(float damage)
    {
        if (damage < 1)
            return;

        CurrentHealth -= damage;

        HealthChanged();
    }

    private void Move()
    {
        transform.LookAt(_target.transform);

        var targetPosition = transform.position
                                + Vector3.forward
                                * Time.deltaTime
                                * SelfInfo.MoveSpeed;

        transform.Translate(targetPosition);
    }
}
