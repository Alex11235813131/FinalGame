using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    private Player _player;
    private float _deltaX = 0.5f;
    private float _deltaY = 0.9f;
    private bool _isNewPosition = false;

    private void OnEnable()
    {
        _player = GetComponentInParent<Player>();
        _player.Mover.PlayerCrouched += OnSetNewPosition;
        _player.Mover.PlayerJumped += OnSetDefaultPosition;
    }

    private void OnDisable()
    {
        _player.Mover.PlayerCrouched -= OnSetNewPosition;
        _player.Mover.PlayerJumped -= OnSetDefaultPosition;
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
        if (_player.Mover.IsPlayerCrouched == false && _isNewPosition == true)
        {
            OnSetDefaultPosition();
        }
    }
}
