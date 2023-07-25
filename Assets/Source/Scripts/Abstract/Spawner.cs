public abstract class Spawner<TObject, TInfo> where TObject : ICreated where TInfo : ICreatedType
{
    protected ObjectFactory<TObject, TInfo> Factory;
    protected ObjectPool<TObject, TInfo> Pool;

    protected Spawner(ObjectFactory<TObject, TInfo> factory, ObjectPool<TObject, TInfo> pool)
    {
        Factory = factory;
        Pool = pool;
    }

    protected abstract TObject GetObject(TInfo info);
    protected abstract TObject CreateObject(TInfo info);
}
