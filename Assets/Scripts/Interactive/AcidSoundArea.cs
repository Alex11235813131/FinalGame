using System.Collections;
using UnityEngine;

public class AcidSoundArea : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _targetVolume;
    [SerializeField] private float _volumeChangeStep;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            StartCoroutine(ChangeVolume(_targetVolume));
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while(_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeChangeStep);
            yield return null;
        }
    }
}
