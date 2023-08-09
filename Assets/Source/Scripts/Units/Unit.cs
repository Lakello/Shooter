using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour, ICreated
{
    public abstract float CurrentHealth { get; }
    public abstract UnitInfo SelfInfo { get; }
    public abstract Type SelfType { get; }

    public abstract event Action<Unit> Dead;
}