public interface ILevelState
{
    public int CurrentWave { get; }
    public int CurrentWaveStage { get; }

    public void NextWave();
    public void NextWaveStage();
}