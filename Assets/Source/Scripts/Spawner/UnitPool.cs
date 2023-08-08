using System.Collections.Generic;
using System.Linq;

public class UnitPool : ObjectPool<Unit, UnitInfo>
{
    private Dictionary<UnitType, List<Unit>> _units = new Dictionary<UnitType, List<Unit>>();

    public override void Return(Unit unit)
    {
        Add(unit);
    }

    public override Unit TryGetObject(UnitInfo info)
    {
        Unit unit = null;

        if (_units.TryGetValue(info.Type, out List<Unit> units))
        {
            if (units == null || units.Count < 1)
                return unit;

            unit = units.First();
            units.Remove(unit);
        }

        return unit;
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
