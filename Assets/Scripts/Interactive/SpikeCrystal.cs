using UnityEngine;

public class SpikeCrystal : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Player>(out Player player);

        if (player)
            player.ApplyDamage(_damage);

    }
}
