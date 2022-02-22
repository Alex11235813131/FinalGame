using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClicked, SettingButtonClicked, ExitButtonClicked;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Play.interactable = false;
        Setting.interactable = false;
        Exit.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Play.interactable = true;
        Setting.interactable = true;
        Exit.interactable = true;
    }

    protected override void OnClickPlayButton()
    {
        RestartButtonClicked?.Invoke();
    }

    protected override void OnClickSettingButton()
    {
        SettingButtonClicked?.Invoke();
    }

    protected override void OnClickExitButton()
    {
        ExitButtonClicked?.Invoke();
    }
}
