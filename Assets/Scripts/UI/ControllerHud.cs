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

    public event UnityAction UpArrowClicked, DownArrowClicked, AttackClicked, SwapWeaponClicked, SettingClicked;

    private void OnEnable()
    {
        _upArrow.onClick.AddListener(OnClickUpArrow);
        _downArrow.onClick.AddListener(OnClickDownArrow);
        _attack.onClick.AddListener(OnClickAttackButton);
        _swapWeapon.onClick.AddListener(OnClickSwapWeaponButton);
        _settings.onClick.AddListener(OnClickSettingButton);
    }

    private void OnDisable()
    {
        _upArrow.onClick.RemoveListener(OnClickUpArrow);
        _downArrow.onClick.RemoveListener(OnClickDownArrow);
        _attack.onClick.RemoveListener(OnClickAttackButton);
        _swapWeapon.onClick.RemoveListener(OnClickSwapWeaponButton);
        _settings.onClick.RemoveListener(OnClickSettingButton);
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

    private void OnClickUpArrow()
    {
        UpArrowClicked?.Invoke();
    }

    private void OnClickDownArrow()
    {
        DownArrowClicked?.Invoke();
    }

    private void OnClickAttackButton()
    {
        AttackClicked?.Invoke();
    }

    private void OnClickSwapWeaponButton()
    {
        SwapWeaponClicked?.Invoke();
    }

    private void OnClickSettingButton()
    {
        SettingClicked?.Invoke();
    }
}
