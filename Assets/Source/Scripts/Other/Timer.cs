using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private float _remainingTime;
    private Coroutine _counterCoroutine;
    private MonoBehaviour _context;

    public float RemainingTime => _remainingTime;

    public event Action TimeIsUp;

    public Timer(MonoBehaviour context)
    {
        _context = context;
    }

    public void Play(float durationInSeconds)
    {
        if (_counterCoroutine != null)
            Stop();

        _counterCoroutine = _context.StartCoroutine(Counter(durationInSeconds));
    }

    public void Stop()
    {
        _context.StopCoroutine(_counterCoroutine);
    }

    private IEnumerator Counter(float duration)
    {
        _remainingTime = duration;

        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;

            yield return null;
        }

        TimeIsUp?.Invoke();

        Stop();
    }
}