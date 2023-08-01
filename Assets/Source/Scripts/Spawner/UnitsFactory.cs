using UnityEngine;

public class UnitsFactory : ObjectFactory<Unit, UnitInfo>
{
    public override Unit GetNewObject(UnitInfo unitInfo)
    {
        var unit = CreateObject<Unit>(unitInfo.Prefab);
        unit.Init(unitInfo);
        return unit;
    }

    protected override T CreateObject<T>(Unit unitPrefab)
    {
        var unit = GameObject.Instantiate(unitPrefab);
        return unit.GetComponent<T>();
    }
}
