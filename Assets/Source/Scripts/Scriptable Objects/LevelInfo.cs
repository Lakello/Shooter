using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "newLevel", menuName = "Level/New level")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private WaveInfo[] _waves;

    public ReadOnlyArray<WaveInfo> Waves => _waves;
}
