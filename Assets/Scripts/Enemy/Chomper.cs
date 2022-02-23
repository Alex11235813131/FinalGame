using UnityEngine;
using UnityEngine.Events;

public class Chomper : Enemy
{
    [SerializeField] private AudioClip _takeDamage;
    [SerializeField] private AudioClip _dying;

    private float _destroingDelay = 1f;
    private const string Death = "Death";

    public event UnityAction<Chomper> Dying;

    public override void TakeDamage(int damage)
    {
        if (HealthPoint > 0)
        {
            _audioSource.PlayOneShot(_takeDamage);
            HealthPoint -= damage;
        }
        else if(HealthPoint <= 0 && IsEnemyDie == false)
        {
            Die();
        }        
    }

    private void Die()
    {
        Dying?.Invoke(this);
        _animator.SetTrigger(Death);
        _audioSource.PlayOneShot(_dying);
        Destroy(gameObject, _destroingDelay);
    }
}
