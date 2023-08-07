using UnityEngine;
using Zenject;

public class LevelStateMachine : MonoBehaviour, ITransitable
{
    [SerializeField] private State _firstState;

    private IState _currentState;
    private LevelInfo _levelInfo;

    private void Awake()
    {
        _currentState = _firstState;

        _currentState?.Enter();
    }

    public void SubscribeTransit(ITransition transition)
    {
        transition.NeedTransit += Transit;
    }

    public void UnsubscribeTransit(ITransition transition)
    {
        transition.NeedTransit -= Transit;
    }

    [Inject]
    private void Init(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
    }

    private void Transit(IState nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;

        _currentState?.Enter();
    }
}
