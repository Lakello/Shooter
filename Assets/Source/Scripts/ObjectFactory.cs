using UnityEngine;

public abstract class ObjectFactory<TObject> where TObject : ICreated
{
    public abstract TObject GetNewObject(TObject @object);
}
 