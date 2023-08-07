public abstract class ObjectPool<TObject, TInfo> where TObject : ICreated where TInfo : ICreatedInfo
{
    public abstract void Add(TObject @object);
    public abstract void Return(TObject @object);
    public abstract TObject TryGetObject(TInfo type);
}
