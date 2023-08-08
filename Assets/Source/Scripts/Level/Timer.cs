using System;
using System.Collections;
using UnityEngine;

public class Timer : ITimeRead, ITimeWrite
{
    private float _remainingTime;
    private Coroutine _counterCoroutine;
    private MonoBehaviour _context;

    public float RemainingTime => _remainingTime;

    public event Action TimerIsRunning;
    public event Action TimeIsUp;

    public Timer(MonoBehaviour context)
    {
        _context = context;
    }

    public void Run(float durationInSeconds)
    {
        if (_counterCoroutine != null)
            Stop();

        _counterCoroutine = _context.StartCoroutine(Counter(durationInSeconds));
    }

    public void Stop()
    {
        if (_context != null)
            _context.StopCoroutine(_counterCoroutine);
    }

    private IEnumerator Counter(float duration)
    {
        TimerIsRunning?.Invoke();

        _remainingTime = duration;

        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;

            yield return null;
        }

        TimeIsUp?.Invoke();
    }
}