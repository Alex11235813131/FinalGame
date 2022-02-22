using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] AudioClip[] _hits;

    private float _lastAttackTime;
    private const string Attack = "Attack";
    private float _animationDelay = 0.5f;

    private void OnEnable()
    {
        _rigidbody.velocity = Vector2.zero;
        _animator.Play(Attack);
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            ApplyDamage(Target);
            _audioSource.PlayOneShot(_hits[Random.Range(0, _hits.Length)]);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void ApplyDamage(Player target)
    {
        StartCoroutine(WaitingAnimation(target));
    }

    private IEnumerator WaitingAnimation(Player target)
    {
        yield return new WaitForSeconds(_animationDelay);
        target.TakeDamage(_damage);
    }
}
