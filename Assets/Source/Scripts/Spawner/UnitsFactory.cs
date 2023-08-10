using UnityEngine;

public class UnitsFactory : ObjectFactory<Unit>
{
    private GameObject _container;
    private Player _player;

    public UnitsFactory(Player player) 
    {
        _container = new GameObject("Container");
        _container.gameObject.tag = _container.name;
        _player = player;
    }

    public override Unit GetNewObject(Unit unit)
    {
        var newUnit = Object.Instantiate(unit);
        newUnit.Init(_player);
        newUnit.gameObject.SetActive(false);
        return newUnit;
    }
}
