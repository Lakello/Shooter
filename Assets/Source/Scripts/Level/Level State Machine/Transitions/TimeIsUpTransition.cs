using System;
using Zenject;

public class TimeIsUpTransition : Transition, IDisposable
{
    private ITimeRead _timeRead;

    public void Dispose()
    {
        _timeRead.TimeIsUp -= Call;
    }

    [Inject]
    private void Init(ITimeRead time)
    {
        _timeRead = time;
        _timeRead.TimeIsUp += Call;
    }
}