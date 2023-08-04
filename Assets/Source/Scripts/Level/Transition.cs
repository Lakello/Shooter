using System;
using UnityEngine;

public abstract class Transition : MonoBehaviour, ITransition
{
    [SerializeField] protected IState TargetState;

    public abstract event Action<IState> NeedTransit;

    public abstract void OnEnable();
    public abstract void OnDisable();
}