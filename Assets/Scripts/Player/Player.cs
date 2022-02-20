using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private WeaponPickUpPoint _weaponPickUpPoint;
    [SerializeField] private Weapon[] _weapons = new Weapon[2];
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private ControllerHud _controllerScreen;

    private PlayerMover _playerMover;
    private int _currentHealth = 5;
    private Weapon _currentWeapon;
    private bool _isWeaponActive = false;
    private int _weaponIndex = 0;

    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction TakeDamage, Dying;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<Weapon> Attack, ChangeWeapon;

    private void OnEnable()
    {
        _weaponPickUpPoint.ActivatedWeapon += OnWeaponPickUp;
        _controllerScreen.AttackClick += OnTryAttack;
        _controllerScreen.SwapWeaponClick += OnSwapWeapon;
    }

    private void OnDisable()
    {
        _weaponPickUpPoint.ActivatedWeapon -= OnWeaponPickUp;
        _controllerScreen.AttackClick -= OnTryAttack;
        _controllerScreen.SwapWeaponClick -= OnSwapWeapon;
    }

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        HealthChanged?.Invoke(_currentHealth);

        for (int i = 0; i < _weapons.Length; i++)
        {
            var result = Instantiate(_weapons[i], transform);
            result.SetBulletPool(_bulletsPool);
            _weapons[i] = result;
        }

        ChangeWeapon?.Invoke(_currentWeapon);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        DyingChecker();
        HealthChanged?.Invoke(_currentHealth);
        TakeDamage?.Invoke();
    }

    private void DyingChecker()
    {
        if (_currentHealth <= 0)
        {
            Dying?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTryAttack()
    {
        if (_isWeaponActive == false || _playerMover.IsOnGround == false)
            return;

        _currentWeapon.Shoot(_shootPoint, transform.localScale.x);
        Attack?.Invoke(_currentWeapon);
    }

    private void OnWeaponPickUp()
    {
        _isWeaponActive = true;
        _currentWeapon = _weapons[_weaponIndex];
        OnSwapWeapon();
    }

    private void OnSwapWeapon()
    {
        if (_currentWeapon == null)
            return;

        if (_currentWeapon.TryGetComponent<Pistol>(out Pistol pistol))
        {
            _currentWeapon = _weapons[++_weaponIndex];
        }
        else
        {
            _currentWeapon = _weapons[--_weaponIndex];
        }

        ChangeWeapon?.Invoke(_currentWeapon);
    }
}
