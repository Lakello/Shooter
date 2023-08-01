using System;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public WaitingState(List<ITransition> transitions) : base(transitions){}

    public override event Action Enable;
    public override event Action Disable;

    public override void Enter()
    {
        Enable?.Invoke();
    }

    public override void Exit()
    {
        Disable?.Invoke();
    }
}