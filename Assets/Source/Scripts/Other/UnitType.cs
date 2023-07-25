using System;
using UnityEngine;

[Serializable]
public class UnitType : ICreatedType
{
    [SerializeField] private Types _type;

    public Types Unit => _type;

    public enum Types
    {
        Warrior,
        Mage,
        Archer
    }
}