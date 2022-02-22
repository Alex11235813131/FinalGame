using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private const string Walk = "Walk";

    private void Start()
    {
        _direction = new Vector2(Target.transform.position.x - transform.position.x, transform.position.y).normalized;
        _animator.SetTrigger(Walk);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}
