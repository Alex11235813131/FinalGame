using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProtectedShield : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _activation;
    [SerializeField] private AudioClip _deactivation;
    [SerializeField] private AudioClip _takeDamage;
    [SerializeField] private ParticleSystem _healEffect;
    [SerializeField] private int _health;

    private Golem _enemyGolem;
    private float _deactivationDelay = 1;
    private const string _deactivate = "Deactivate";
    private const string _activate = "Activate";
    private bool _isDeactivation;

    public Enemy EnemyGolem => _enemyGolem;

    private void Start()
    {
        _enemyGolem = GetComponentInParent<Golem>();
    }

    private void OnEnable()
    {
        _isDeactivation = false;
        _animator.SetTrigger(_activate);
        _audioSource.PlayOneShot(_activation);
        _healEffect.Play();
    }

    private void FixedUpdate()
    {
        if (_isDeactivation == true)
            return;

        if(_audioSource.isPlaying == false)
            _audioSource.Play();

        if(_health <= 0 || _enemyGolem.CurrentHealth == _enemyGolem.MaxHealth)
        {
            _healEffect.Stop();
            _audioSource.Stop();
            _audioSource.PlayOneShot(_deactivation);
            _animator.Play(_deactivate);
            StartCoroutine(Deactivation());
        }
    }

    private IEnumerator Deactivation()
    {
        _isDeactivation = true;
        yield return new WaitForSeconds(_deactivationDelay);
        gameObject.SetActive(false);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        _audioSource.PlayOneShot(_takeDamage);
    }
}
