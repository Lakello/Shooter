using System;
using UnityEngine;
using Zenject;

public class TimeIsUpTransition : Transition
{
    [SerializeField] private float _durationInSeconds;

    private Timer _timer;
    private ITransitable _stateMachine;

    public override event Action<IState> NeedTransit;

    public override void OnEnable()
    {
        _stateMachine.SubscribeTransit(this);
        _timer.TimeIsUp += Call;
        _timer.Play(_durationInSeconds);
    }

    public override void OnDisable()
    {
        _stateMachine.UnsubscribeTransit(this);
        _timer.Stop();
        _timer.TimeIsUp -= Call;
    }

    [Inject]
    private void Init(Timer timer, ITransitable stateMachine)
    {
        _stateMachine = stateMachine;
        _timer = timer;
    }

    private void Call()
    {
        NeedTransit?.Invoke(TargetState);
    }
}
