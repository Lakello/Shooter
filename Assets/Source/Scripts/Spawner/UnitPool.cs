using System;
using System.Collections.Generic;

public class UnitPool : ObjectPool<Unit>
{
    private Dictionary<Type, Queue<Unit>> _units = new Dictionary<Type, Queue<Unit>>();

    public override void Return(Unit unit)
    {
        unit.Dead -= Return;

        Add(unit);
    }

    public override Unit TryGetObject(Unit needUnit)
    {
        if (_units.TryGetValue(needUnit.SelfType, out Queue<Unit> units))
        {
            if (units.Count > 0)
            {
                var unit = units.Dequeue();

                return unit;
            }
        }

        return null;
    }

    protected override void Add(Unit unit)
    {
        if (!_units.ContainsKey(unit.SelfType))
            AddType(unit.SelfType);

        if (_units.TryGetValue(unit.SelfType, out Queue<Unit> units))
        {
            unit.gameObject.SetActive(false);
            units.Enqueue(unit);
        }
    }

    private void AddType(Type type)
    {
        _units.Add(type, new Queue<Unit>());
    }
}
