using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour, ITakeDamage, IAttack
{
    private float _currentHealth;

    public event Action Dead;

    private void Awake()
    {
        _currentHealth = 100;
    }

    public void Attack()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (damage < 1)
            return;

        _currentHealth -= damage;
    }
}