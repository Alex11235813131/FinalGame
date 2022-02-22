using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Golem : Enemy
{
    [SerializeField] Player _player;
    [SerializeField] AudioClip _takeDamage;
    [SerializeField] AudioClip _dying;
    [SerializeField] GameObject _protectiveShield;

    private float _healDelay = 3f;
    private float _delayTimer;
    private float _destoyingDelay = 8.5f;
    private float _healUpCoefficient = 0.1f;
    private const string Death = "Death";

    public event UnityAction Dying;

    private void Start()
    {
        _target = _player;
    }

    private void FixedUpdate()
    {
        if (_protectiveShield.activeSelf == true)
            IncreaseHealth();
    }

    public override void TakeDamage(int damage)
    {
        if (_protectiveShield.activeSelf == true)
            return;

        if (CurrentHealthPoint > 0)
        {
            _audioSource.PlayOneShot(_takeDamage);
            CurrentHealthPoint -= damage;
        }
        else if (CurrentHealth <= 0 && IsEnemyDie == false)
        {
            Die();
        }
    }

    private void Die()
    {
        Dying?.Invoke();
        _animator.SetTrigger(Death);
        _audioSource.PlayOneShot(_dying);
        Destroy(gameObject, _destoyingDelay);
        IsEnemyDie = true;
    }

    private void IncreaseHealth()
    {
        if(_delayTimer >= _healDelay)
        {
            CurrentHealthPoint += HealthPoint * _healUpCoefficient;
            _delayTimer = 0;
        }

        _delayTimer += Time.deltaTime;
    }
}
