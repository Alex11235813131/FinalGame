using UnityEngine;

public class FightState : State
{
    [SerializeField] private Attack[] _attacks;
    [SerializeField] private float _delay;

    private float _lastAttackTime = 2;
    private const string Activation = "Activation";

    private void OnEnable()
    {
        _animator.SetTrigger(Activation);
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            _attacks[Random.Range(0, _attacks.Length)].Shoot();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }
}
