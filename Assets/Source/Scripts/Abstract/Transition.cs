using System;
using UnityEngine;

[Serializable]
public class Transition : ITransition
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    public Transition(State targetState)
    {
        _targetState = targetState;
    }

    public event Action NeedTransit;
}
