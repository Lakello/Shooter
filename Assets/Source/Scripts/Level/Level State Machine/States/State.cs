using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public abstract class State : MonoBehaviour, IState
{
    [SerializeField] private List<Transition> _transitions;

    protected IReadOnlyList<ITransition> Transitions => _transitions;

    public void OnEnable()
    {
        foreach (var transition in Transitions) 
        {
            transition.TurnOn();
        }
    }

    private void OnDisable()
    {
        foreach (var transition in Transitions)
        {
            transition.TurnOff();
        }
    }

    public abstract void Enter();
    public abstract void Exit();
}
