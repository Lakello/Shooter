using UnityEngine;
using Zenject;

public class WaitingState : State
{
    public override void Enter()
    {
        Debug.Log("WAITING");
    }

    public override void Exit()
    {
        Debug.Log("NON WAITING");
    }
}