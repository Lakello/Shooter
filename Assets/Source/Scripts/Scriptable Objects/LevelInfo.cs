using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "newLevel", menuName = "Level/New level")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private float _delayBetweenWavesInSeconds = 30f;
    [SerializeField] private float _delayBeforeStartOfLevelInSeconds = 60f;
    [SerializeField] private WaveInfo[] _waves;

    public float DelayBetweenWavesInSeconds => _delayBetweenWavesInSeconds;
    public ReadOnlyArray<WaveInfo> Waves => _waves;
}
