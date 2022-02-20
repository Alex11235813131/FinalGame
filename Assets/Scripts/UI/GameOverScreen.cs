using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClick, SettingButtonClick, ExitButtonClick;

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

    protected override void OnPlayButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
    protected override void OnSettingButtonClick()
    {
        SettingButtonClick?.Invoke();
    }

    protected override void OnExitButtonClick()
    {
        ExitButtonClick?.Invoke();
    }
}