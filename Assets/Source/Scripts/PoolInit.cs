public class PoolInit<TObject, TInfo>
{
    public UnitsFactory UnitsFactory { get; private set; }
    public PoolList<TObject, TInfo> PoolList { get; private set; }

    public PoolInit(UnitsFactory factory, PoolList<TObject, TInfo> poolList)
    {
        UnitsFactory = factory;
        PoolList = poolList;
    }
}
