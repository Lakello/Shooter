public abstract class PoolList<TObject, TInfo>
{
    public abstract void Add(TInfo info, TObject @object);
    public abstract TObject TryGetObject(TInfo info);
}
