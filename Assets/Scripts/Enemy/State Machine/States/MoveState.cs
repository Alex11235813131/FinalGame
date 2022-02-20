using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private const string _walk = "Walk";

    private void Start()
    {
        _direction = new Vector2(Target.transform.position.x - transform.position.x, transform.position.y).normalized;
        _animator.SetTrigger(_walk);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}
