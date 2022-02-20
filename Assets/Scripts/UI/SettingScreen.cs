using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SettingScreen : Screen
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _closeScreenButton;

    public event UnityAction VolumeChanged, CloseScreenButtonDown, RestartButtonClick, ExitButtonClick;

    private void OnEnable()
    {
        _closeScreenButton.onClick.AddListener(OnCloseScreenButtonDown);
        _slider.onValueChanged.AddListener(delegate { OnValaueChange(); });
    }

    private void OnDisable()
    {
        _closeScreenButton.onClick.RemoveListener(OnCloseScreenButtonDown);
        _slider.onValueChanged.RemoveListener(delegate { OnValaueChange(); });
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _closeScreenButton.interactable = false;
        Play.interactable = false;
        Exit.interactable = false;
        _slider.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _closeScreenButton.interactable = true;
        Play.interactable = true;
        Exit.interactable = true;
        _slider.interactable = true;
    }

    private void OnCloseScreenButtonDown()
    {
        CloseScreenButtonDown?.Invoke();
    }

    private void OnValaueChange()
    {
        VolumeChanged?.Invoke();
    }

    protected override void OnPlayButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
    protected override void OnExitButtonClick()
    {
        ExitButtonClick?.Invoke();
    }

    protected override void OnSettingButtonClick()
    {
    }
}
