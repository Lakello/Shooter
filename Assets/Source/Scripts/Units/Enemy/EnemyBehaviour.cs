using UnityEngine;

[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(IAttack))]
[RequireComponent(typeof(EnemyMover))]
public class EnemyBehaviour : MonoBehaviour
{
    private Unit _unit;
    private IAttack _attack;
    private EnemyMover _enemyMover;

    private Player _target => _unit.Target;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _attack = GetComponent<IAttack>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _target.transform.position);

        if (distance > _unit.SelfInfo.AttackDistance)
        {
            _enemyMover.Move(_target.transform, _unit.SelfInfo.MoveSpeed);
        }
        else
        {
            _attack.Attack();
        }
    }
}