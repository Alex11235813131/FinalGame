using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private WeaponPickUpPoint _weaponPickUpPoint;
    [SerializeField] private Weapon[] _weapons = new Weapon[2];
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private ControllerHud _controllerScreen;

    private int _currentHealth = 5;
    private Weapon _currentWeapon;
    private bool _isWeaponActive = false;
    private int _weaponIndex = 0;

    public PlayerMover Mover => _playerMover;
    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction TakedDamage, Dying;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<Weapon> AppliedDamage, ChangedWeapon;


    private void OnEnable()
    {
        _weaponPickUpPoint.ActivatedWeapon += OnWeaponPickUp;
        _controllerScreen.AttackClicked += OnTryAttack;
        _controllerScreen.SwapWeaponClicked += OnSwapWeapon;
    }

    private void OnDisable()
    {
        _weaponPickUpPoint.ActivatedWeapon -= OnWeaponPickUp;
        _controllerScreen.AttackClicked -= OnTryAttack;
        _controllerScreen.SwapWeaponClicked -= OnSwapWeapon;
    }

    private void Start()
    {      
        HealthChanged?.Invoke(_currentHealth);

        for (int i = 0; i < _weapons.Length; i++)
        {
            var result = Instantiate(_weapons[i], transform);
            result.SetBulletPool(_bulletsPool);
            _weapons[i] = result;
        }

        ChangedWeapon?.Invoke(_currentWeapon);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            Die();
        }

        HealthChanged?.Invoke(_currentHealth);
        TakedDamage?.Invoke();
    }

    private void Die()
    {
        Dying?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnTryAttack()
    {
        if (_isWeaponActive == false || Mover.IsOnGround == false)
            return;

        _currentWeapon.Shoot(_shootPoint, transform.localScale.x);
        AppliedDamage?.Invoke(_currentWeapon);
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

        ChangedWeapon?.Invoke(_currentWeapon);
    }
}
