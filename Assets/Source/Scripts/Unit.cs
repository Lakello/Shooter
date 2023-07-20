using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int CurrentHealth;

    protected abstract float Damage { get; }
    protected abstract float AttackDistance { get; }
}