using System;

public class Level
{
    private LevelInfo _levelInfo;
    private StateMachine _stateMachine;

    public Level(LevelInfo levelInfo, StateMachine stateMachine)
    {
        _levelInfo = levelInfo;
        _stateMachine = stateMachine;
    }

    public event Action<UnitType> SpawnEnemy;


}
