using UnityEngine;

public class Staff : Weapon
{
    private HitPoint _hitPoint;

    private void Start()
    {
        _hitPoint = GetComponentInChildren<HitPoint>();
    }

    public override void Shoot(Transform shootPoint, float scale)
    {
        _audioSource.PlayOneShot(_audioClips[Random.Range(0,_audioClips.Length)]);
        _hitPoint.gameObject.SetActive(true);
    }

    public override void SetBulletPool(ObjectPool pool)
    {
    }
}
