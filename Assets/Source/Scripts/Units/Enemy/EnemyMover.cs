using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    public void Move(Transform target)
    {
        _agent.SetDestination(target.position);
    }
}