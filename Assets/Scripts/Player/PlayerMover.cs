using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private ControllerHud _controllerScreen;

    private Rigidbody2D _rigidbody;
    private bool _isDirectionRigth = true;
    private bool _isPlayerCrouched = false;
    private Vector2 _moveDirection;
    private RaycastHit2D[] _results;
    private const float _castDistance = 0.1f;

    public bool IsOnGround { get; private set; }
    public Vector2 MoveDirection => _moveDirection;
    public float Speed => _speed;
    public bool IsDirectionRigth => _isDirectionRigth;
    public bool IsPlayerCrouched => _isPlayerCrouched;

    public event UnityAction PlayerJumped, PushingBlock, PlayerCrouched, PlayerStandUp;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _controllerScreen.UpArrowClick += OnJump;
        _controllerScreen.DownArrowClick += OnCrouch;
    }

    private void OnDisable()
    {
        _controllerScreen.UpArrowClick -= OnJump;
        _controllerScreen.DownArrowClick -= OnCrouch;
    }

    private void FixedUpdate()
    {
        Mover();
        GroundPositionChecker();
        PushableBlockDetector();
    }

    public void MoveButtonDown(float directionX)
    {
        _moveDirection = new Vector2(directionX, 0);
        _isPlayerCrouched = false;
    }

    private void Mover()
    {
        _rigidbody.velocity = new Vector2(_moveDirection.x * _speed, _rigidbody.velocity.y);

        if (_moveDirection.x > 0 && !_isDirectionRigth)
            ChangeSpriteDirection();
        else if(_moveDirection.x < 0 && _isDirectionRigth)
            ChangeSpriteDirection();
    }

    private void OnJump()
    {
        if (IsOnGround == true)
        {
            PlayerJumped?.Invoke();
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

        _isPlayerCrouched = false;
    }

    private void OnCrouch()
    {
        if (IsOnGround == true)
        {
            if(_isPlayerCrouched == true)
            {
                PlayerStandUp?.Invoke();
                _isPlayerCrouched = false;
            }
            else
            {
                PlayerCrouched?.Invoke();
                _isPlayerCrouched = true;
            }
        }
    }

    private void ChangeSpriteDirection()
    {
        _isDirectionRigth = !_isDirectionRigth;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void GroundPositionChecker()
    {
        if (PlayerCollisionChecker(Vector2.down, _castDistance) > 0)
            IsOnGround = true;
        else
            IsOnGround = false;
    }

    private void PushableBlockDetector()
    {
        PlayerCollisionChecker(_moveDirection, _castDistance);

        foreach (var result in _results)
        {
            if (result == false)
                return;

            if(result.collider.TryGetComponent<PushableBlock>(out PushableBlock block))
                PushingBlock?.Invoke();
        }
    }

    private int PlayerCollisionChecker(Vector2 direction, float distance)
    {
        _results = new RaycastHit2D[1];
        return _rigidbody.Cast(direction, _results, distance);
    }
}
