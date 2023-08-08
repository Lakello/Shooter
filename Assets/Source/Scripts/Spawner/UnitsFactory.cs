using UnityEngine;

public class UnitsFactory : ObjectFactory<Unit>
{
    private GameObject _container;

    public UnitsFactory() 
    {
        _container = Object.Instantiate(new GameObject());
        _container.gameObject.name = "Container";
        _container.gameObject.tag = _container.name;
    }

    public override Unit GetNewObject(Unit unit)
    {
        return Object.Instantiate(unit, _container.transform);
    }
}
