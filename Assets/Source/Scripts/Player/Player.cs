using System;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    private float _currentHealth;

    public event Action Dead;

    private void Awake()
    {
        _currentHealth = 100;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 1)
            return;

        _currentHealth -= damage;
    }
}