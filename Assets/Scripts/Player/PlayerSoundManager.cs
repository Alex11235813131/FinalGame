using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _steps;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip[] _takeDamage;
    [SerializeField] private Player _player;

    private void FixedUpdate()
    {
        PlayerMoves();
    }

    private void OnEnable()
    {
        _player.Mover.PlayerJumped += OnPlayerJumped;
        _player.TakeDamage += OnPlayerTakeDamage;
    }

    private void OnDisable()
    {
        _player.Mover.PlayerJumped -= OnPlayerJumped;
        _player.TakeDamage -= OnPlayerTakeDamage;
    }

    private void OnPlayerJumped()
    {
        _audioSource.PlayOneShot(_jump);
    }

    private void OnPlayerTakeDamage()
    {
        _audioSource.clip = _takeDamage[Random.Range(0, _takeDamage.Length - 1)];
        _audioSource.Play();
    }

    private void PlayerMoves()
    {
        if (_audioSource.isPlaying)
            return;

        if (_player.Mover.MoveDirection.x != 0 && _player.Mover.IsOnGround)
        {
            _audioSource.clip = _steps[Random.Range(0, _steps.Length - 1)];
            _audioSource.Play();
        }
    }
}
