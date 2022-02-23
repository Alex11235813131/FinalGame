using System.Collections;
using UnityEngine;

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
    private bool _isDeactivated;
    private const string Deactivate = "Deactivate";
    private const string Activate = "Activate";

    public Enemy EnemyGolem => _enemyGolem;

    private void Start()
    {
        _enemyGolem = GetComponentInParent<Golem>();
    }

    private void OnEnable()
    {
        _isDeactivated = false;
        _animator.SetTrigger(Activate);
        _audioSource.PlayOneShot(_activation);
        _healEffect.Play();
    }

    private void FixedUpdate()
    {
        if (_isDeactivated == true)
            return;

        if(_audioSource.isPlaying == false)
            _audioSource.Play();

        if(_health <= 0 || _enemyGolem.CurrentHealth == _enemyGolem.MaxHealth)
        {
            _healEffect.Stop();
            _audioSource.Stop();
            _audioSource.PlayOneShot(_deactivation);
            _animator.Play(Deactivate);
            StartCoroutine(Deactivation());
        }
    }

    private IEnumerator Deactivation()
    {
        _isDeactivated = true;
        yield return new WaitForSeconds(_deactivationDelay);
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _audioSource.PlayOneShot(_takeDamage);
    }
}
