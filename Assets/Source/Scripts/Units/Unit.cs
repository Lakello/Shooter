using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour, ICreated
{
    public abstract float CurrentHealth { get; }
    public abstract UnitInfo SelfInfo { get; }
    public abstract Type SelfType { get; }
    public abstract Player Target { get; }

    public abstract event Action<Unit> Dead;

    public abstract void Init(Player player);
}