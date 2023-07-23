using UnityEngine;

public abstract class Unit : MonoBehaviour, ICreated
{
    [SerializeField] protected float CurrentHealth;


    public abstract void Init(UnitInfo unitInfo);
}