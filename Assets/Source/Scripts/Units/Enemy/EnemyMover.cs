using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public void Move(Transform target, float moveSpeed)
    {
        transform.LookAt(target.transform);

        var targetPosition = transform.position
                                + moveSpeed
                                * Time.deltaTime
                                * Vector3.forward;

        transform.Translate(targetPosition);
    }
}