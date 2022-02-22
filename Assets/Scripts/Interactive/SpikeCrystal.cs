using UnityEngine;

public class SpikeCrystal : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            player.ApplyDamage(_damage);
    }
}
