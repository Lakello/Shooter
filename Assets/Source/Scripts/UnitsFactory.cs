using UnityEngine;

public class UnitsFactory
{
    private UnitInfo _warrior;

    public UnitsFactory(UnitInfo warrior, UnitInfo)
    {
        _warrior = warrior;
    }

    public Archer CreateArcher()
    {
        var archer = GetNewUnitComponent<Archer>();
        archer.Init(_warrior);
        return archer;
    }

    public Mage CreateMage()
    {
        var mage = GetNewUnitComponent<Mage>();
        mage.Init(_warrior);
        return mage;
    }

    public Warrior CreateWarrior()
    {
        var warrior = GetNewUnitComponent<Warrior>();
        warrior.Init(_warrior);
        return warrior;
    }

    private T GetNewUnitComponent<T>()
    {
        var warrior = GameObject.Instantiate(_warrior.Prefab);
        return warrior.GetComponent<T>();
    }
}
