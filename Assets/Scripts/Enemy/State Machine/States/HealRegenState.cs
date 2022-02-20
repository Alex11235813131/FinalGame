using UnityEngine;

public class HealRegenState : State
{
    [SerializeField] private AudioClip _deactivate;
    [SerializeField] private GameObject _protectedShield;

    private const string _disable = "Disable";

    private void OnEnable()
    {
        _animator.Play(_disable);
        _audioSource.PlayOneShot(_deactivate);
        _protectedShield.SetActive(true);
    }
}
