using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Player>(out Player player);

        if (player)
        {
            _audioSource.Play();
            player.ApplyDamage(_damage);
        }
    }
}
