using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class StateMachine
{
    [SerializeField] private State[] _states;

    protected Dictionary<Type, State> States;
    protected State CurrentState;

    protected StateMachine()
    {
        if (_states != null)
        {
            foreach (var state in _states)
            {
                AddState(state);
            }
        }
    }

    public void EnterIn<TState>() where TState : State
    {
        if (States.TryGetValue(typeof(TState), out State state))
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }

    private void AddState(State state)
    {
        Type type = state.GetType();

        if (States.ContainsKey(type) == false)
        {
            States.Add(type, state);
        }
    }
}