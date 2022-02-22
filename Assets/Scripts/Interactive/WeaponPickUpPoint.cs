using UnityEngine;
using UnityEngine.Events;

public class WeaponPickUpPoint : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Sprite _imageAfterPickUp;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isPickUp = false;

    public event UnityAction ActivatedWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player) && _isPickUp == false)
        {
            ActivatedWeapon?.Invoke();
            _spriteRenderer.sprite = _imageAfterPickUp;
            _audioSource.Play();
            _isPickUp = true;
        }
    }
}
