using System.Collections.Generic;
using System;
using Zenject;

public abstract class StateMachine
{
    protected Dictionary<Type, State> States;
    protected State CurrentState;

    public StateMachine(Func<Dictionary<Type, State>> states)
    {
        States = states();
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

    [Inject]
    private void Init(IFirstState firstState)
    {
        CurrentState = firstState as State;
        CurrentState.Enter();
    }
}