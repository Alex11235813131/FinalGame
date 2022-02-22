using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Play;
    [SerializeField] protected Button Setting;
    [SerializeField] protected Button Exit;

    public CanvasGroup ScreenCanvasGroup => CanvasGroup;

    private void OnEnable()
    {
        Play.onClick.AddListener(OnClickPlayButton);
        Setting.onClick.AddListener(OnClickSettingButton);
        Exit.onClick.AddListener(OnClickExitButton);
    }

    private void OnDisable()
    {
        Play.onClick.AddListener(OnClickPlayButton);
        Setting.onClick.AddListener(OnClickSettingButton);
        Exit.onClick.AddListener(OnClickExitButton);
    }

    protected abstract void OnClickPlayButton();
    protected abstract void OnClickSettingButton();
    protected abstract void OnClickExitButton();

    public abstract void Open();
    public abstract void Close();
}
