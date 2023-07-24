using System;
using System.Collections;
using UnityEngine;

public class EndWait : Transition
{
    public override event Action Go;

    private Coroutine _waitingCoroutine;
    private float _time;

    public EndWait(float time)
    {
        _time = time;
    }

    public override void Enter()
    {
        _waitingCoroutine = StartCoroutine(Waiting(_time));
    }

    public override void Exit()
    {
        StopCoroutine(_waitingCoroutine);
    }

    private IEnumerator Waiting(float time)
    {
        yield return new WaitForSeconds(time);

        Go?.Invoke();
    }
}