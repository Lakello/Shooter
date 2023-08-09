public abstract class ObjectPool<TObject> where TObject : ICreated
{
    public abstract void Return(TObject @object);
    public abstract TObject TryGetObjectByType(System.Type objectType);
    protected abstract void Add(TObject @object);
}
