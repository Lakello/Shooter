using System;
using System.Collections;

public class Level
{
    private LevelInfo _levelInfo;
    private Timer _timer;

    public Level(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        _timer = new Timer();
    }

    public event Action<UnitInfo> SpawnEnemy;

    private IEnumerator Fight()
    {
        yield return null;
    }
}
