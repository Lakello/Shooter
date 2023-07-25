using UnityEngine;

public abstract class ObjectFactory<TObject, TInfo> where TObject : ICreated where TInfo : ICreatedType
{
    public abstract TObject GetNewObject(TInfo info);

    protected abstract T CreateObject<T>(TObject unitPrefab);
}
 