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
        var warrior = GameObject.Instantiate(unitPrefab);
        return warrior.GetComponent<T>();
    }
}
