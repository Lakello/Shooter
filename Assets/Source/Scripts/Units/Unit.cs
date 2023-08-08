using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour, ICreated
{ 
    public UnitInfo SelfInfo { get; protected set; }
    
    [SerializeField] protected float CurrentHealth;

    public abstract void Init(UnitInfo unitInfo);
}