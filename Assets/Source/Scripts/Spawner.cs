using UnityEngine;

public abstract class Spawner<TObject, TInfo> : MonoBehaviour
{
    protected PoolInit<TObject, TInfo> PoolInit;

    protected abstract TObject GetObject(TInfo info);
    protected abstract TObject CreateObject(TInfo info);
}
