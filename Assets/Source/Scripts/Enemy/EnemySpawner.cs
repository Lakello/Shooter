using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
}
