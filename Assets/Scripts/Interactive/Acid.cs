using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            player.TakeDamage(_damage);
        }
    }
}
