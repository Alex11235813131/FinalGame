using UnityEngine;
using UnityEngine.Events;

public class Chomper : Enemy
{
    [SerializeField] private AudioClip _takeDamage;
    [SerializeField] private AudioClip _dying;

    private const string _death = "Death";
    private float _destroingDelay = 1f;

    public event UnityAction<Chomper> Dying;

    public override void TakeDamage(int damage)
    {
        if (HealthPoint <= 0)
            return;

        _audioSource.PlayOneShot(_takeDamage);
        HealthPoint -= damage;
        DyingChecker();
    }

    private void DyingChecker()
    {
        if (HealthPoint <= 0)
        {
            Dying?.Invoke(this);
            _animator.SetTrigger(_death);
            _audioSource.PlayOneShot(_dying);
            Destroy(gameObject, _destroingDelay);
        }
    }
}
