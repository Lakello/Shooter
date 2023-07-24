using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    private LevelStateMachine _levelStateMachine;
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _levelStateMachine = new LevelStateMachine();
        _levelStateMachine.EnterIn<InitializeLevelState>();

        _enemySpawner = new EnemySpawner(gameObject, new UnitsFactory(), new UnitPool());
    }
}
