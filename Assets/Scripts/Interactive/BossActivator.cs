using UnityEngine;
using UnityEngine.Events;

public class BossActivator : MonoBehaviour
{
    public event UnityAction Reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Reached?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
