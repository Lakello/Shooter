using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private PlayerInput _input;

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Update()
    {
        Vector2 input = _input.Player.Move.ReadValue<Vector2>();

        Move(input);
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Move(Vector2 input)
    {
        if (input.sqrMagnitude < 0.1f)
            return;

        float scaleMoveSpeed = _speed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0)
                            * new Vector3(input.x, 0, input.y);

        transform.position += move * scaleMoveSpeed;
    }

    [Inject]
    private void Init(PlayerInput input)
    {
        _input = input;
    }
}
