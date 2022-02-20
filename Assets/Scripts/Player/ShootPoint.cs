using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    private PlayerMover _playerMover;
    private float _deltaX = 0.5f;
    private float _deltaY = 0.9f;
    private bool _isNewPosition = false;

    private void OnEnable()
    {
        _playerMover = GetComponentInParent<PlayerMover>();
        _playerMover.PlayerCrouched += OnSetNewPosition;
        _playerMover.PlayerJumped += OnSetDefaultPosition;
    }

    private void OnDisable()
    {
        _playerMover.PlayerCrouched -= OnSetNewPosition;
        _playerMover.PlayerJumped -= OnSetDefaultPosition;
    }

    private void OnSetNewPosition()
    {
        transform.position = new Vector3(transform.position.x - _deltaX, transform.position.y - _deltaY);
        _isNewPosition = true;
    }

    private void OnSetDefaultPosition()
    {
        if(_isNewPosition == true)
        {
            transform.position = new Vector3(transform.position.x + _deltaX, transform.position.y + _deltaY);
            _isNewPosition = false;
        }
    }

    private void Update()
    {
        if (_playerMover.IsPlayerCrouched == false && _isNewPosition == true)
        {
            OnSetDefaultPosition();
        }
    }
}
