using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class TimerView : MonoBehaviour
{
    private TMP_Text _timerText;
    private ITimeRead _timer;
    private Coroutine _timerCoroutine;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _timer.TimerIsRunning += OnTimerIsRunning;
        _timer.TimeIsUp += OnTimeIsUp;
    }

    private void OnDisable()
    {
        _timer.TimerIsRunning -= OnTimerIsRunning;
        _timer.TimeIsUp -= OnTimeIsUp;
    }

    private void OnTimerIsRunning()
    {
        ResetTimer();

        _timerCoroutine = StartCoroutine(ShowRemainingTime());
    }

    private void OnTimeIsUp()
    {
        ResetTimer();
    }

    private IEnumerator ShowRemainingTime()
    {
        while (_timer.RemainingTime >= 0)
        {
            _timerText.text = _timer.RemainingTime.ToString("0");

            yield return null;
        }

        ResetTimer();
    }

    private void ResetTimer()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerText.text = 0.ToString();
        }
    }

    [Inject]
    private void Init(ITimeRead read)
    {
        _timer = read;
    }
}
