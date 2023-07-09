using UnityEngine;
using UnityEngine.Events;

public class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer _layer;
    [SerializeField] private int _chance;

    public GridLayer Layer => _layer;
    public int Chance => _chance;

    public event UnityAction<GridObject> TooFarAway;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, 1, 100);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            TooFarAway?.Invoke(this);
        }
    }
}
