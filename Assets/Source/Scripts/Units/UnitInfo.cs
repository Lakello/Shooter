using UnityEngine;

[CreateAssetMenu(fileName = "newUnitInfo", menuName = "Unit/New Unit")]
public class UnitInfo : ScriptableObject, ICreatedInfo
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private UnitType _type;

    public UnitType Type => _type;
    public float MaxHealth => _maxHealth;
    public float Damage => _damage;
    public float AttackDistance => _attackDistance;
    public float AttackSpeed => _attackSpeed;
    public float MoveSpeed => _moveSpeed;
}
