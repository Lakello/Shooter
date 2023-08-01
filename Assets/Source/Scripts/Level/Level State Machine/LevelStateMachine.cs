using System;
using UnityEngine;
using Zenject;

public class LevelStateMachine : IStateMachine
{
    private IState _firstState;
    private IState _currentState;
    private LevelInfo _levelInfo;
    private ITimeWrite _timer;

    [Inject]
    public LevelStateMachine(ITimeWrite timer, IState firstState, LevelInfo levelInfo)
    {
        _firstState = firstState;
        _levelInfo = levelInfo;
        _timer = timer;

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
