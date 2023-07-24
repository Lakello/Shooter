using System;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public abstract event Action Go;

    public abstract void Enter();
    public abstract void Exit();
}