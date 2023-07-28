using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;

    public CelebrationState(List<Transition> transitions) : base(transitions)
    {
    }

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //_animator.Play(EnemyAnimatorController.States.Celebration);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
