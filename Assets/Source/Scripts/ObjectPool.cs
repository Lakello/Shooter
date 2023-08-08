public abstract class ObjectPool<TObject, TInfo> where TObject : ICreated where TInfo : ICreatedInfo
{
    public abstract void Return(TObject @object);
    public abstract TObject TryGetObject(TInfo type);
    protected abstract void Add(TObject @object);
}
