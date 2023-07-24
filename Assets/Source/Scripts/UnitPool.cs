using System.Collections.Generic;
using System.Linq;

public class UnitPool : ObjectPool<Unit, UnitInfo>
{
    private HashSet<UnitNode> _units = new HashSet<UnitNode>();

    public override void Add(UnitInfo info, Unit unit)
    {
        if (!Contains(info.Type))
            AddType(info.Type);

        _units.First(t => t.Type == info.Type).Units.Add(unit);
    }

    public override Unit TryGetObject(UnitInfo info)
    {
        return _units.FirstOrDefault(u => u.Type == info.Type)
            .Units.FirstOrDefault(u => u.gameObject.activeSelf == false);
    }

    private void AddType(UnitType type)
    {
        UnitNode node = new UnitNode();
        node.Type = type;
        node.Units = new HashSet<Unit>();

        _units.Add(node);
    }

    private bool Contains(UnitType type)
    {
        UnitNode node = new();
        node.Type = type;

        return _units.Contains(node);
    }
}
