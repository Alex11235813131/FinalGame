using UnityEngine;

public class Pistol : Weapon
{
    private ObjectPool _bulletsPool;

    public override void Shoot(Transform shootPoint, float scale)
    {
        if (_bulletsPool.TryGetObject(out GameObject bullet))
        {
            SetBullet(bullet, shootPoint, scale);
            _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
        }
    }

    private void SetBullet(GameObject bullet, Transform shootPoint, float scale)
    {
        bullet.gameObject.transform.localScale = 
            new Vector3(scale, bullet.gameObject.transform.localScale.y, bullet.gameObject.transform.localScale.z);
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootPoint.position;
    }

    public override void SetBulletPool(ObjectPool pool)
    {
        _bulletsPool = pool;
    }
}
