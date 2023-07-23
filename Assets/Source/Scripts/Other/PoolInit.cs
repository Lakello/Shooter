public class PoolInit<TObject, TInfo> where TObject : ICreated where TInfo : ICreatedInfo
{
    public UnitsFactory UnitsFactory { get; private set; }
    public PoolList<TObject, TInfo> PoolList { get; private set; }

    public PoolInit(UnitsFactory factory, PoolList<TObject, TInfo> poolList)
    {
        UnitsFactory = factory;
        PoolList = poolList;
    }
}
