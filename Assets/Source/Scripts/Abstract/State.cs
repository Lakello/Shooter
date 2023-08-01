using System;
using System.Collections.Generic;
using Zenject;

public abstract class State : IState, IDisposable
{
    private List<ITransition> _transitions;

    protected IReadOnlyList<ITransition> Transitions => _transitions;

    public State(List<ITransition> transitions)
    {
        _transitions = transitions;

        Enable += Subscribe;
        Disable += UnSubscribe;
    }

    public abstract event Action Enable;
    public abstract event Action Disable;

    public abstract void Enter();
    public abstract void Exit();

    [Inject]
    public void Dispose()
    {
        UnSubscribe();

        Enable += Subscribe;
        Disable += UnSubscribe;
    }

    private void Subscribe()
    {
        if (Transitions == null || Transitions.Count < 1)
            return;

        foreach (var transition in Transitions) 
        {
            Enable += transition.OnEnable;
            Disable += transition.OnDisable;
        }
    }

    private void UnSubscribe()
    {
        if (Transitions == null || Transitions.Count < 1)
            return;

        foreach (var transition in Transitions)
        {
            Enable -= transition.OnEnable;
            Disable -= transition.OnDisable;
        }
    }
}
