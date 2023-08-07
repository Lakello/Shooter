using UnityEngine;
using Zenject;

public class PreparationState : State, IFirstState
{
    private LevelInfo _levelInfo;
    private ITimeWrite _timeWrite;

    public override void Enter()
    {
        _timeWrite.Play(_levelInfo.DelayBeforeStartOfLevelInSeconds);
        

        Debug.Log("PREPARATION");
    }

    public override void Exit()
    {
        Debug.Log("NON PREPARATION");
    }

    private void Transit(Transition transition)
    {
        LevelStateMachine.EnterIn<FightState>();
    }

    [Inject]
    private void Init(LevelInfo levelInfo, ITimeWrite write, TimeIsUpTransition timeIsUp)
    {
        _levelInfo = levelInfo;
        _timeWrite = write;

        timeIsUp.NeedTransit += Transit;

        var gg = Object.Instantiate(new GameObject());
        gg.name = "PREPARATION";
    }
}