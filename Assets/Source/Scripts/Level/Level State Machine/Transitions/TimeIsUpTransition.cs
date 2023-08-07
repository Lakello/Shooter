using System;
using UnityEngine;
using Zenject;

public class TimeIsUpTransition : Transition
{
    [SerializeField] private float _durationInSeconds;

    private ITimeRead _timerRead;
    private ITimeWrite _timerWrite;
    private ITransitable _stateMachine;

    public override void OnEnable()
    {
        _stateMachine.SubscribeTransit(this);
        _timerRead.TimeIsUp += Call;
        _timerWrite.Play(_durationInSeconds);
    }

    public override void OnDisable()
    {
        _stateMachine.UnsubscribeTransit(this);
        _timerWrite.Stop();
        _timerRead.TimeIsUp -= Call;
    }

    [Inject]
    private void Init(ITimeRead read, ITimeWrite write, ITransitable stateMachine)
    {
        _stateMachine = stateMachine;
        _timerRead = read;
        _timerWrite = write;
    }
}
