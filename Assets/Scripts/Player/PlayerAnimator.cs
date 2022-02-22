using UnityEngine;

[RequireComponent(typeof(Player), typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

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

    private void Update()
    {
        Walk();
        _animator.SetBool(_onGround, _player.Mover.IsOnGround);
    }

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();

        _player.Mover.PlayerJumped += OnJump;
        _player.Mover.PushingBlock += OnPushingBlock;
        _player.Mover.PlayerCrouched += OnPlayerCrouched;
        _player.Mover.PlayerStandUp += OnPlayerStandUp;
        _player.TakeDamage += OnApplyDamage;
        _player.Dying += OnDying;
        _player.Attack += OnAttack;
        _player.ChangeWeapon += OnCurrentWeaponChecker;
    }

    private void OnDisable()
    {
        _player.Mover.PlayerJumped -= OnJump;
        _player.Mover.PushingBlock -= OnPushingBlock;
        _player.Mover.PlayerCrouched -= OnPlayerCrouched;
        _player.Mover.PlayerStandUp -= OnPlayerStandUp;
        _player.TakeDamage -= OnApplyDamage;
        _player.Dying -= OnDying;
        _player.Attack -= OnAttack;
        _player.ChangeWeapon -= OnCurrentWeaponChecker;
    }

    private void Walk()
    {
        _animator.SetFloat(_vectorX, Mathf.Abs(_player.Mover.MoveDirection.x));
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
