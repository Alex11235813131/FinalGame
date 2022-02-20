using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int HealthPoint;

    protected float CurrentHealthPoint;
    protected Player _target;
    protected Animator _animator;
    protected AudioSource _audioSource;

    public float MaxHealth => HealthPoint;
    public float CurrentHealth => CurrentHealthPoint;
    public Player Target => _target;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        CurrentHealthPoint = HealthPoint;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public abstract void TakeDamage(int damage);
}
