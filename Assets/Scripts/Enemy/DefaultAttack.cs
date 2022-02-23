using System.Collections;
using UnityEngine;

public class DefaultAttack : Attack
{
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private AudioClip _shootSound;

    private float _delay = 1.5f;
    private float _timer;
    private const string _defaultAttack = "DefaultAttack";

    public override void Shoot()
    {
        if (_bulletsPool.TryGetObject(out GameObject bullet))
            SetBullet(bullet, _shootPoint);
    }

    private void SetBullet(GameObject bullet, Transform shootPoint)
    {
        AnimationDelay();
        _audioSource.PlayOneShot(_shootSound);
        bullet.transform.position = new Vector3(shootPoint.position.x, shootPoint.position.y);
        bullet.SetActive(true);
    }

    private void AnimationDelay()
    {
        _animator.SetTrigger(_defaultAttack);
        _timer = 0;

        while (_timer < _delay)
        {
            _timer += Time.deltaTime;
        }
    }
}
