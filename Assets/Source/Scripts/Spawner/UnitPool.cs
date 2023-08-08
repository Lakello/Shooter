using System.Collections.Generic;
using System.Linq;

public class UnitPool : ObjectPool<Unit>
{
    private Dictionary<UnitType, List<Unit>> _units = new Dictionary<UnitType, List<Unit>>();

    public override void Return(Unit unit)
    {
        Add(unit);
    }

    public override Unit TryGetObject(Unit unit)
    {
        if (_units.TryGetValue(unit.SelfInfo.Type, out List<Unit> units))
        {
            if (units == null || units.Count < 1)
                return null;

            var obtainedUnit = units.First();
            units.Remove(obtainedUnit);

            UnityEngine.Debug.Log("Получен из пула");

            return obtainedUnit;
        }

        return null;
    }

    protected override void Add(Unit unit)
    {
        if (!_units.ContainsKey(unit.SelfInfo.Type))
            AddType(unit.SelfInfo.Type);

        if (_units.TryGetValue(unit.SelfInfo.Type, out List<Unit> units))
        {
            unit.gameObject.SetActive(false);
            units.Add(unit);
        }
    }

    private void AddType(UnitType type)
    {
        _units.Add(type, new List<Unit>());
    }
}
