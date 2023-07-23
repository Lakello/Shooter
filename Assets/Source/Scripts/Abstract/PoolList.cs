public abstract class PoolList<TObject, TInfo> where TObject : ICreated where TInfo : ICreatedInfo 
{
    public abstract void Add(TInfo info, TObject @object);
    public abstract TObject TryGetObject(TInfo info);
}
