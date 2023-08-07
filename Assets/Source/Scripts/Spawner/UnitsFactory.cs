using UnityEngine;

public class UnitsFactory : ObjectFactory<Unit, UnitInfo>
{
    private GameObject _container;

    public UnitsFactory() 
    {
        _container = Object.Instantiate(new GameObject());
        _container.gameObject.name = "Container";
    }

    public override Unit GetNewObject(UnitInfo unitInfo)
    {
        var unit = CreateObject(unitInfo.Prefab);
        unit.Init(unitInfo);
        return unit;
    }

    protected override Unit CreateObject(Unit unitPrefab)
    {
        var unit = Object.Instantiate(unitPrefab, _container.transform);
        return unit.GetComponent<Unit>();
    }
}
