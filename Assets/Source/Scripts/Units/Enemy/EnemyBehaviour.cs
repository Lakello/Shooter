using UnityEngine;
using UnityEngine.AI;

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

    private void OnEnable()
    {
        _enemyMover.Move(_target.transform);
    }

    private void Update()
    {
        if (CanAttack())
        {
            _attack.Attack();
        }
        else
        {
            _enemyMover.Move(_target.transform);
        }
    }

    private bool CanAttack()
    {
        return Vector3.Distance(transform.position, _target.transform.position) < _unit.SelfInfo.AttackDistance;
    }
}