using UnityEngine;

[RequireComponent(typeof(Player), typeof(Animator), typeof(PlayerMover))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Player _player;

    private const string _vectorX = "VectorX";
    private const string _onGround = "OnGround";
    private const string _jump = "Jump";
    private const string _pushingBlock = "PushingBlock";
    private const string _applyDamage = "ApplyDamage";
    private const string _death = "Death";
    private const string _crouch = "Crouch";
    private const string _standUp = "StandUp";
    private const string _staffAttack = "StaffAttack";
    private const string _pistolIdle = "PistolIdle";
    private const string _isWeaponPistol = "isPistolCurrentWeapon";

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Walk();
        _animator.SetBool(_onGround, _mover.IsOnGround);
    }

    private void OnEnable()
    {
        _mover.PlayerJumped += OnJump;
        _mover.PushingBlock += OnPushingBlock;
        _mover.PlayerCrouched += OnPlayerCrouched;
        _mover.PlayerStandUp += OnPlayerStandUp;
        _player.TakeDamage += OnApplyDamage;
        _player.Dying += OnDying;
        _player.Attack += OnAttack;
        _player.ChangeWeapon += OnCurrentWeaponChecker;
    }

    private void OnDisable()
    {
        _mover.PlayerJumped -= OnJump;
        _mover.PushingBlock -= OnPushingBlock;
        _mover.PlayerCrouched -= OnPlayerCrouched;
        _mover.PlayerStandUp -= OnPlayerStandUp;
        _player.TakeDamage -= OnApplyDamage;
        _player.Dying -= OnDying;
        _player.Attack -= OnAttack;
        _player.ChangeWeapon -= OnCurrentWeaponChecker;
    }

    private void Walk()
    {
        _animator.SetFloat(_vectorX, Mathf.Abs(_mover.MoveDirection.x));
    }

    private void OnJump()
    {
        _animator.SetTrigger(_jump);
    }

    private void OnApplyDamage()
    {
        _animator.SetTrigger(_applyDamage);
    }

    private void OnDying()
    {
        _animator.Play(_death);
    }

    private void OnPushingBlock()
    {
        _animator.Play(_pushingBlock);
    }

    private void OnAttack(Weapon weapon)
    {
        if (weapon.TryGetComponent<Staff>(out Staff staff))
            _animator.Play(_staffAttack);

        OnCurrentWeaponChecker(weapon);
    }

    private void OnPlayerCrouched()
    {
        _animator.SetTrigger(_crouch);
    }

    private void OnPlayerStandUp()
    {
        _animator.SetTrigger(_standUp);
    }

    private void OnCurrentWeaponChecker(Weapon weapon)
    {
        if (weapon == null)
            return;

        if (weapon.TryGetComponent<Pistol>(out Pistol pistol))
        {
            _animator.SetTrigger(_pistolIdle);
            _animator.SetBool(_isWeaponPistol, true);
        }
        else
        {
            _animator.SetBool(_isWeaponPistol, false);
        }
    }
}
