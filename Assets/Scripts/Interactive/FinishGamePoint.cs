using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FinishGamePoint : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _delay = 1f;

    public event UnityAction Reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            StartCoroutine(ReachedSoundDelay());
        }
    }

    private IEnumerator ReachedSoundDelay()
    {
        yield return new WaitForSeconds(_delay);
        Reached?.Invoke();
    }
}
