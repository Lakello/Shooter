using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : ObjectsPool<GridObject>
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _cellSize;

    private HashSet<Vector3Int> _collisionsMatrix = new HashSet<Vector3Int>();

    private void Update()
    {
        FillRadius(_player.position, _viewRadius);
    }

    protected override void EnableObject(GridObject poolingObject)
    {
        poolingObject.gameObject.SetActive(true);
        poolingObject.TooFarAway += OnTooFarAway;
    }

    protected override void DisableObject(GridObject poolingObject)
    {
        poolingObject.TooFarAway -= OnTooFarAway;

        poolingObject.gameObject.SetActive(false);
    }

    private void OnTooFarAway(GridObject gridObject)
    {
        var gridPosition = WorldToGridPosition(gridObject.transform.position);
        _collisionsMatrix.Remove(gridPosition);

        DisableObject(gridObject);
    }

    private void FillRadius(Vector3 center, float viewRadius)
    {
        var cellCountOnAxis = (int)(viewRadius / _cellSize);
        var fillAreaCenter = WorldToGridPosition(center);

        for (int x = -cellCountOnAxis; x < cellCountOnAxis; x++)
        {
            for (int z = -cellCountOnAxis; z < cellCountOnAxis; z++)
            {
                TrySetOnLayer(GridLayer.Ground, fillAreaCenter + new Vector3Int(x, 0, z));
                TrySetOnLayer(GridLayer.OnGround, fillAreaCenter + new Vector3Int(x, 0, z));
            }
        }
    }

    private void TrySetOnLayer(GridLayer layer, Vector3Int gridPosition)
    {
        var template = TryGetRandomTemplate(layer);
        if (template == null)
            return;

        gridPosition.y = (int)layer;
        if (_collisionsMatrix.Contains(gridPosition))
            return;
        else
            _collisionsMatrix.Add(gridPosition);

        var position = GridToWorldPosition(gridPosition);

        template.transform.position = position;
        template.transform.rotation = Quaternion.identity;
        template.transform.parent = transform;
        EnableObject(template);
    }

    private GridObject TryGetRandomTemplate(GridLayer layer)
    {
        var variants = Pool.Where(template => template.Layer == layer && 
                                  template.gameObject.activeSelf == false);

        if (variants.Count() == 1)
            return variants.First();

        foreach (var template in variants)
        {
            if (template.Chance > Random.Range(0, 100))
            {
                return template;
            }
        }

        return null;
    }

    private Vector3 GridToWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize,
            gridPosition.z * _cellSize);
    }

    private Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector3Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize),
            (int)(worldPosition.z / _cellSize));
    }
}
