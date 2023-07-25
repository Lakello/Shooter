public abstract class ObjectPool<TObject, TInfo> where TObject : ICreated where TInfo : System.Enum
{
    public abstract void Add(TObject @object);
    public abstract void Return(TObject @object);
    public abstract TObject TryGetObject(T type);
}
