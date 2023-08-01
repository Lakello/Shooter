using System;
using UnityEngine;

public abstract class Transition : ITransition
{
    protected IState TargetState;

    public Transition(IState targetState)
    {
        TargetState = targetState;
    }

    public abstract event Action<IState> NeedTransit;

    public abstract void OnEnable();
    public abstract void OnDisable();
}