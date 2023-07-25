using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _remainingTime;
    private Coroutine _counterCoroutine;

    public float RemainingTime => _remainingTime;

    public event Action TimeIsUp;

    public void Play(float durationInSeconds)
    {
        if (_counterCoroutine != null)
            Stop();

        _counterCoroutine = StartCoroutine(Counter(durationInSeconds));
    }

    public void Stop()
    {
        StopCoroutine(_counterCoroutine);
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