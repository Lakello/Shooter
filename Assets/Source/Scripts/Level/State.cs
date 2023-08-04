using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class State : MonoBehaviour, IState
{
    [SerializeField] private List<ITransition> _transitions;

    protected IReadOnlyList<ITransition> Transitions => _transitions;

    public void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public abstract void Enter();
    public abstract void Exit();
}
