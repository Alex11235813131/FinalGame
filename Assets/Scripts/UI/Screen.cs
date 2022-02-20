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
        Play.onClick.AddListener(OnPlayButtonClick);
        Setting.onClick.AddListener(OnSettingButtonClick);
        Exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        Play.onClick.AddListener(OnPlayButtonClick);
        Setting.onClick.AddListener(OnSettingButtonClick);
        Exit.onClick.AddListener(OnExitButtonClick);
    }

    protected abstract void OnPlayButtonClick();
    protected abstract void OnSettingButtonClick();
    protected abstract void OnExitButtonClick();

    public abstract void Open();
    public abstract void Close();
}
