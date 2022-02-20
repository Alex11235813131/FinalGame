using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ControllerHud : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _leftArrow;
    [SerializeField] private Button _rigthArrow;
    [SerializeField] private Button _upArrow;
    [SerializeField] private Button _downArrow;
    [SerializeField] private Button _attack;
    [SerializeField] private Button _swapWeapon;
    [SerializeField] private Button _settings;

    public event UnityAction UpArrowClick, DownArrowClick, AttackClick, SwapWeaponClick, SettingClick;

    private void OnEnable()
    {
        _upArrow.onClick.AddListener(OnUpArrowClick);
        _downArrow.onClick.AddListener(OnDownArrowClick);
        _attack.onClick.AddListener(OnAttackClick);
        _swapWeapon.onClick.AddListener(OnSwapWeaponClick);
        _settings.onClick.AddListener(OnSettingClick);
    }

    private void OnDisable()
    {
        _upArrow.onClick.RemoveListener(OnUpArrowClick);
        _downArrow.onClick.RemoveListener(OnDownArrowClick);
        _attack.onClick.RemoveListener(OnAttackClick);
        _swapWeapon.onClick.RemoveListener(OnSwapWeaponClick);
        _settings.onClick.RemoveListener(OnSettingClick);
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _leftArrow.interactable = false;
        _rigthArrow.interactable = false;
        _upArrow.interactable = false;
        _downArrow.interactable = false;
        _attack.interactable = false;
        _swapWeapon.interactable = false;
        _settings.interactable = false;
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _leftArrow.interactable = true;
        _rigthArrow.interactable = true;
        _upArrow.interactable = true;
        _downArrow.interactable = true;
        _attack.interactable = true;
        _swapWeapon.interactable = true;
        _settings.interactable = true;
    }

    private void OnUpArrowClick()
    {
        UpArrowClick?.Invoke();
    }

    private void OnDownArrowClick()
    {
        DownArrowClick?.Invoke();
    }

    private void OnAttackClick()
    {
        AttackClick?.Invoke();
    }

    private void OnSwapWeaponClick()
    {
        SwapWeaponClick?.Invoke();
    }

    private void OnSettingClick()
    {
        SettingClick?.Invoke();
    }
}
