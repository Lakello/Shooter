using System;
using UnityEngine;
using Zenject;

public class LevelStateMachine : MonoBehaviour, ITransitable
{
    private IState _firstState;
    private IState _currentState;

    [Inject]
    public void Init(IState firstState, LevelInfo levelInfo)
    {
        _firstState = firstState;

        Reset();
    }

    public void SubscribeTransit(ITransition transition)
    {
        transition.NeedTransit += Transit;
    }

    public void UnsubscribeTransit(ITransition transition)
    {
        transition.NeedTransit -= Transit;
    }

    private void Reset()
    {
        _currentState = _firstState;

        _currentState?.Enter();
    }

    private void Transit(IState nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;

        _currentState?.Enter();
    }
}
