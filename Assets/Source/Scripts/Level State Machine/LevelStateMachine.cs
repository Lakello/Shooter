using UnityEngine;
using Zenject;

public class LevelStateMachine : IInitializable
{
    [SerializeField] private State _firstState;

    private State _currentState;

    public State Current => _currentState;

    public void Initialize()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState?.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
