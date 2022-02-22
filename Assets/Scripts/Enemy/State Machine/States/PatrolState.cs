using System.Collections;
using UnityEngine;

public class PatrolState : State
{
    private int _speed = 2;
    private Vector2 _moveDirection = Vector2.left;
    private const string _idle = "Idle";

    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PatrolPoint>(out PatrolPoint point))
            StartCoroutine(ChangeMoveDirection());
    }

    private IEnumerator ChangeMoveDirection()
    {
        var CurrentSpeed = _speed;
        _speed = 0;
        _animator.Play(_idle);
        yield return new WaitForSeconds(1f);
        _moveDirection.x = -_moveDirection.x;
        _speed = CurrentSpeed;
        SpriteDirectionSetter();
    }

    private void SpriteDirectionSetter()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
