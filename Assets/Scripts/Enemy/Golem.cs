using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Golem : Enemy
{
    [SerializeField] Player _player;
    [SerializeField] AudioClip _takeDamage;
    [SerializeField] AudioClip _dying;
    [SerializeField] GameObject _protectedShield;

    private float _healDelay = 3f;
    private float _delayTimer;
    private float _destoyingDelay = 8.5f;
    private float _healUpCoefficient = 0.1f;
    private bool _isDeactivate = false;
    private const string _death = "Death";

    public event UnityAction Dying;

    private void Start()
    {
        _target = _player;
    }

    private void FixedUpdate()
    {
        if (_protectedShield.activeSelf == true)
            HealthUp();
    }

    public override void TakeDamage(int damage)
    {
        if (_isDeactivate == true || _protectedShield.activeSelf == true)
            return;

        DyingChecker();
        _audioSource.PlayOneShot(_takeDamage);
        CurrentHealthPoint -= damage;
    }

    private void HealthUp()
    {
        if(_delayTimer >= _healDelay)
        {
            CurrentHealthPoint += HealthPoint * _healUpCoefficient;
            _delayTimer = 0;
        }

        _delayTimer += Time.deltaTime;
    }

    private void DyingChecker()
    {
        if (CurrentHealthPoint <= 0)
        {
            Dying?.Invoke();
            _animator.SetTrigger(_death);
            _audioSource.PlayOneShot(_dying);
            Destroy(gameObject, _destoyingDelay);
            _isDeactivate = true;
        }
    }
}
