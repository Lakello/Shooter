using UnityEngine;
using Zenject;

public class PreparationState : State, IFirstState
{
    private TimeIsUpTransition _timeIsUp;
    private LevelInfo _levelInfo;
    private ITimeWrite _timeWrite;

    public override void Enter()
    {
        _timeIsUp.NeedTransit += Transit;

        _timeWrite.Run(_levelInfo.DelayBeforeStartOfLevelInSeconds);

        Debug.Log("PREPARATION");
    }

    public override void Exit()
    {
        _timeIsUp.NeedTransit -= Transit;
        Debug.Log("NON PREPARATION");
    }

    private void Transit()
    {
        StateMachine.EnterIn<FightState>();
    }

    [Inject]
    private void Init(LevelInfo levelInfo, ITimeWrite write, TimeIsUpTransition timeIsUp)
    {
        _levelInfo = levelInfo;
        _timeWrite = write;
        _timeIsUp = timeIsUp;        
    }
}