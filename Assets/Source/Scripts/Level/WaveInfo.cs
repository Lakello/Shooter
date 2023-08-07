using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "newWave", menuName = "Level/New Wave")]
public class WaveInfo : ScriptableObject
{
    [SerializeField] private WaveStage[] _stages;

    public ReadOnlyArray<WaveStage> Stages => _stages;
}
