using UnityEngine;
using Zenject.SpaceFighter;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    private Rigidbody _selfRigidbody;

    private void Awake()
    {
        _selfRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Transform target, float moveSpeed)
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();

        _selfRigidbody.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}