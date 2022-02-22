using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;

    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    protected Enemy _enemy;
    protected AudioSource _audioSource;

    protected Player Target { get; private set; }

    public void Enter(Player target)
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transit in _transitions)
            {
                transit.enabled = true;
                transit.Init(target);
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (var transit in _transitions)
                transit.enabled = false;

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transit in _transitions)
        {
            if(transit.NeedTransit)
                return transit.TargetState;
        }

        return null;
    }
}
