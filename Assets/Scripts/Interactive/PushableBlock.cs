using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Vector2 _moveDirection = Vector2.zero;
    private RaycastHit2D[] _raycastResult = new RaycastHit2D[1];

    private void FixedUpdate()
    {
        if (_moveDirection == Vector2.zero)
            return;

        DistancetoPlayerChecker();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
            _moveDirection = player.GetComponent<PlayerMover>().MoveDirection.normalized;
    }

    private void DistancetoPlayerChecker()
    {
        Player player = null;

        _raycastResult = Physics2D.LinecastAll(transform.position, 
            new Vector2(transform.position.x - _moveDirection.x, transform.position.y));

        foreach (var item in _raycastResult)
        {
            item.collider.TryGetComponent<Player>(out player);

            if(player == null)
                continue;
        }

        SoundActivator(player);
    }

    private void SoundActivator(Player player)
    {
        if (player == null)
        {
            _audioSource.Stop();
            _moveDirection = Vector2.zero;
        }
        else if (player != null && _audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
    }
}
