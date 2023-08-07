using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class Transition
{
    public event Action<Transition> NeedTransit;

    protected void Call()
    {
        NeedTransit?.Invoke(this);
    }
}