using System;

public class TimeIsUpTransition : Transition
{
    private ITimeRead _timer;

    public TimeIsUpTransition(ITimeRead timer, IState targetState) : base(targetState)
    {
        _timer = timer;
    }

    public override event Action<IState> NeedTransit;

    public override void OnEnable()
    {

    }

    public override void OnDisable()
    {

    }
}
