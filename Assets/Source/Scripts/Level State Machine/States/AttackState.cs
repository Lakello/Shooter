using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private float _lastAttackTime;

    public AttackState(List<Transition> transitions) : base(transitions)
    {
    }

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (_lastAttackTime <= 0)
        //{
        //    Attack(Target);

        //    _lastAttackTime = _delay;
        //}

        //_lastAttackTime -= Time.deltaTime;
    }

    private void Attack( )
    {
        //_animator.Play(EnemyAnimatorController.States.Attack);
        //target.ApplyDamage(_damage);
    }
}
