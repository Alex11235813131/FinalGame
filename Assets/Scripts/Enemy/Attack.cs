using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public abstract class Attack : MonoBehaviour
{
    protected Animator _animator;
    protected AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public abstract void Shoot();
}
