using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip[] _audioClips;

    public abstract void Shoot(Transform shootPoint, float scale);

    public abstract void SetBulletPool(ObjectPool pool);
}
