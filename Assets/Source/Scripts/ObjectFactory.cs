using UnityEngine;

public abstract class ObjectFactory<TObject, TInfo>
{
    public abstract TObject GetNewObject(TInfo info);

    protected abstract T CreateObject<T>(TObject unitPrefab);
}
 