using UnityEngine;

[RequireComponent(typeof(Player), typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private const string VectorX = "VectorX";
    private const string OnGround = "OnGround";
    private const string Jump = "Jump";
    private const string PushingBlock = "PushingBlock";
    private const string ApplyDamage = "ApplyDamage";
    private const string Death = "Death";
    private const string Crouch = "Crouch";
    private const string StandUp = "StandUp";
    private const string StaffAttack = "StaffAttack";
    private const string PistolIdle = "PistolIdle";
    private const string IsWeaponPistol = "isPistolCurrentWeapon";

    private void Update()
    {
        Walk();
        _animator.SetBool(OnGround, _player.Mover.IsOnGround);
    }

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _player.Mover.Jumped += OnJump;
        _player.Mover.BlockPushing += OnPushingBlock;
        _player.Mover.Crouched += OnCrouched;
        _player.Mover.GotUp += OnStandUp;
        _player.TakedDamage += OnTakeDamage;
        _player.Dying += OnDying;
        _player.AppliedDamage += OnApplyDamage;
        _player.ChangedWeapon += OnCheckCurrentWeapon;
    }

    private void OnDisable()
    {
        _player.Mover.Jumped -= OnJump;
        _player.Mover.BlockPushing -= OnPushingBlock;
        _player.Mover.Crouched -= OnCrouched;
        _player.Mover.GotUp -= OnStandUp;
        _player.TakedDamage -= OnTakeDamage;
        _player.Dying -= OnDying;
        _player.AppliedDamage -= OnApplyDamage;
        _player.ChangedWeapon -= OnCheckCurrentWeapon;
    }

    private void Walk()
    {
        _animator.SetFloat(VectorX, Mathf.Abs(_player.Mover.MoveDirection.x));
    }

    private void OnJump()
    {
        _animator.SetTrigger(Jump);
    }

    private void OnTakeDamage()
    {
        _animator.SetTrigger(ApplyDamage);
    }

    private void OnDying()
    {
        _animator.Play(Death);
    }

    private void OnPushingBlock()
    {
        _animator.Play(PushingBlock);
    }

    private void OnApplyDamage(Weapon weapon)
    {
        if (weapon.TryGetComponent<Staff>(out Staff staff))
            _animator.Play(StaffAttack);

        OnCheckCurrentWeapon(weapon);
    }

    private void OnCrouched()
    {
        _animator.SetTrigger(Crouch);
    }

    private void OnStandUp()
    {
        _animator.SetTrigger(StandUp);
    }

    private void OnCheckCurrentWeapon(Weapon weapon)
    {
        if (weapon == null)
            return;

        if (weapon.TryGetComponent<Pistol>(out Pistol pistol))
        {
            _animator.SetTrigger(PistolIdle);
            _animator.SetBool(IsWeaponPistol, true);
        }
        else
        {
            _animator.SetBool(IsWeaponPistol, false);
        }
    }
}
