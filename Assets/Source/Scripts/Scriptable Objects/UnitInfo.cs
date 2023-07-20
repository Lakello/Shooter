using UnityEngine;

[CreateAssetMenu(fileName = "newUnitInfo", menuName = "Unit/New Unit")]
public abstract class UnitInfo : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Unit _prefab;

    public Unit Prefab => _prefab;
    public float MaxHealth => _maxHealth;
    public float Damage => _damage;
    public float AttackDistance => _attackDistance;
}
