using System;
using UnityEngine;

public abstract class Transition : MonoBehaviour, ITransition
{
    [SerializeField] private State _targetState;

    protected IState TargetState => _targetState;

    public event Action<IState> NeedTransit;

    public abstract void OnEnable();
    public abstract void OnDisable();

    public void TurnOn()
    {
        enabled = true;
    }

    public void TurnOff()
    {
        enabled = false;
    }

    protected void Call()
    {
        NeedTransit?.Invoke(TargetState);
    }
}