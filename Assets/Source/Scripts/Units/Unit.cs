using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public abstract class Unit : MonoBehaviour, ICreated, IInitializable
{
    [SerializeField] protected float CurrentHealth;

    [SerializeField] private UnitInfo _selfInfo;

    public UnitInfo SelfInfo => _selfInfo;

    public event Action<Unit> Dead;

    public void Initialize()
    {
        CurrentHealth = _selfInfo.MaxHealth;
    }

    protected void HealthChanged()
    {
        if (CurrentHealth <= 0)
            Dead?.Invoke(this);
    }
}