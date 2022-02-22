using UnityEngine;

public class HealRegenState : State
{
    [SerializeField] private AudioClip _deactivate;
    [SerializeField] private GameObject _protectedShield;

    private const string Disable = "Disable";

    private void OnEnable()
    {
        _animator.Play(Disable);
        _audioSource.PlayOneShot(_deactivate);
        _protectedShield.SetActive(true);
    }
}
