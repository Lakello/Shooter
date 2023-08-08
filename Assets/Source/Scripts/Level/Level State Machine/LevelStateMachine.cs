using Zenject;

public class LevelStateMachine : StateMachine, ILevelStateRead, ILevelStateWrite
{
    private LevelInfo _levelInfo;
    private int _currentWaveIndex;
    private int _currentStageIndex;

    public int CurrentWaveIndex => _currentWaveIndex;
    public int CurrentStageIndex => _currentStageIndex;

    public bool TryNextWave()
    {
        if (CurrentWaveIndex < _levelInfo.Waves.Count - 1)
        {
            _currentWaveIndex++;
            _currentStageIndex = 0;
            return true;
        }

        return false;
    }

    public bool TryNextStage()
    {
        if (CurrentStageIndex < _levelInfo.Waves[CurrentWaveIndex].Stages.Count - 1)
        {
            _currentStageIndex++;
            return true;
        }

        return false;
    }

    [Inject]
    private void Init(LevelInfo levelInfo) => _levelInfo = levelInfo;
}
