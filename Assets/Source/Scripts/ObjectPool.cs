public abstract class ObjectPool<TObject> where TObject : ICreated
{
    public abstract void Return(TObject @object);
    public abstract TObject TryGetObject(TObject @object);
    protected abstract void Add(TObject @object);
}
