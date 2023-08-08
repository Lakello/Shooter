using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, ITakeDamage, IAttack
{
    private float _currentHealth;

    public event Action Dead;
    
    private GameObject _container;
    private PlayerInput _input;

    private void Awake()
    {
        _currentHealth = 100;
    }

    private void Start()
    {
        _container = GameObject.FindWithTag("Container");
    }

    private void Update()
    {
        if (_input.Player.Attack.ReadValue<bool>())
        {
            var enemy = _container.GetComponentInChildren<ITakeDamage>();

            enemy.TakeDamage(1000);
        }
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

    [Inject]
    private void Init(PlayerInput input)
    {
        _input = input;
    }
}