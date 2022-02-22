using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SettingScreen : Screen
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _closeScreenButton;

    public event UnityAction VolumeChanged, CloseScreenButtonClicked, RestartButtonClicked, ExitButtonClicked;

    private void OnEnable()
    {
        _closeScreenButton.onClick.AddListener(OnClickCloseScreenButton);
        _slider.onValueChanged.AddListener(delegate { OnChangeVolume(); });
    }

    private void OnDisable()
    {
        _closeScreenButton.onClick.RemoveListener(OnClickCloseScreenButton);
        _slider.onValueChanged.RemoveListener(delegate { OnChangeVolume(); });
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

    private void OnClickCloseScreenButton()
    {
        CloseScreenButtonClicked?.Invoke();
    }

    private void OnChangeVolume()
    {
        VolumeChanged?.Invoke();
    }

    protected override void OnClickPlayButton()
    {
        RestartButtonClicked?.Invoke();
    }
    protected override void OnClickExitButton()
    {
        ExitButtonClicked?.Invoke();
    }

    protected override void OnClickSettingButton()
    {
    }
}
