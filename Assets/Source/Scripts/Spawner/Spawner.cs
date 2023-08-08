public abstract class Spawner<TObject> where TObject : ICreated
{
    protected ObjectFactory<TObject> Factory;
    protected ObjectPool<TObject> Pool;

    protected Spawner(ObjectFactory<TObject> factory, ObjectPool<TObject> pool)
    {
        Factory = factory;
        Pool = pool;
    }

    public abstract void OnSpawn(TObject info);
    protected abstract TObject GetObject(TObject info);
    protected abstract TObject CreateObject(TObject info);
}
