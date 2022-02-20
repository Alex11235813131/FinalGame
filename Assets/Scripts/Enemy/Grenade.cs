using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _animationDelay;
    [SerializeField] private float _deactivationDelay;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody.AddForce(Vector2.left * _speed);
        StartCoroutine(AnimationDelayBeforeActivation());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator AnimationDelayBeforeActivation()
    {
        yield return new WaitForSeconds(_animationDelay);
        StartCoroutine(DeactivationDelay());
    }

    private IEnumerator DeactivationDelay()
    {
        yield return new WaitForSeconds(_deactivationDelay);
        gameObject.SetActive(false);
    }
}
