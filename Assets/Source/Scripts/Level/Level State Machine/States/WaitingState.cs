using System;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public override void Enter()
    {
        enabled = true;
        Debug.Log("WAITING");
    }

    public override void Exit()
    {
        enabled = false;
        Debug.Log("NON WAITING");
    }
}