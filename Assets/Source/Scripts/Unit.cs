using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected float CurrentHealth;


    public abstract void Init(UnitInfo unitInfo);
}