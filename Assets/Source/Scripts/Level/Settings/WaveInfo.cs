using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "newWave", menuName = "Level/New Wave")]
public class WaveInfo : ScriptableObject
{
    [SerializeField] private float _delayBetweenStagesInSeconds = 5f;
    [SerializeField] private WaveStage[] _stages;

    public float DelayBetweenStagesInSeconds => _delayBetweenStagesInSeconds;
    public ReadOnlyArray<WaveStage> Stages => _stages;
}
