using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private FinishGamePoint _finishGamePoint;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private SettingScreen _settingScreen;
    [SerializeField] private ControllerHud _controllerScreen;

    private void OnEnable()
    {
        _player.Dying += OnDie;

        _finishGamePoint.Reached += OnReachedFinishPoint;

        _startScreen.PlayButtonClicked += OnClickPlayButton;
        _startScreen.SettingButtonClicked += OnClickSettingButton;
        _startScreen.ExitButtonClicked += OnClickExitButton;

        _settingScreen.CloseScreenButtonClicked += OnClickCloseScreenButton;
        _settingScreen.RestartButtonClicked += OnClickRestartButton;
        _settingScreen.ExitButtonClicked += OnClickExitButton;

        _gameOverScreen.RestartButtonClicked += OnClickRestartButton;
        _gameOverScreen.SettingButtonClicked += OnClickSettingButton;
        _gameOverScreen.ExitButtonClicked += OnClickExitButton;

        _controllerScreen.SettingClicked += OnClickSettingButton;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDie;
        _finishGamePoint.Reached -= OnReachedFinishPoint;

        _startScreen.PlayButtonClicked -= OnClickPlayButton;
        _startScreen.SettingButtonClicked -= OnClickSettingButton;
        _startScreen.ExitButtonClicked -= OnClickExitButton;

        _settingScreen.CloseScreenButtonClicked -= OnClickCloseScreenButton;
        _settingScreen.RestartButtonClicked -= OnClickRestartButton;
        _settingScreen.ExitButtonClicked -= OnClickExitButton;

        _gameOverScreen.RestartButtonClicked -= OnClickRestartButton;
        _gameOverScreen.SettingButtonClicked -= OnClickSettingButton;
        _gameOverScreen.ExitButtonClicked -= OnClickExitButton;

        _controllerScreen.SettingClicked -= OnClickSettingButton;
    }

    private void Start()
    {
        _startScreen.Open();
    }

    private void OnClickPlayButton()
    {
        _player.gameObject.SetActive(true);
        _startScreen.Close();
        _controllerScreen.Open();
        Time.timeScale = 1;
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene(0);
    }

    private void OnClickSettingButton()
    {
        Time.timeScale = 0;
        _controllerScreen.Close();
        _settingScreen.Open();
    }

    private void OnClickExitButton()
    {
        Application.Quit();
    }

    private void OnDie()
    {
        _controllerScreen.Close();
        _gameOverScreen.Open();
    }

    private void OnClickCloseScreenButton()
    {
        _settingScreen.Close();

        if (_startScreen.ScreenCanvasGroup.alpha == 0 && _gameOverScreen.ScreenCanvasGroup.alpha == 0)
        {
            _controllerScreen.Open();
        }
        else if(_startScreen.ScreenCanvasGroup.alpha == 1)
        {
            return;
        }

        Time.timeScale = 1;
    }

    private void OnReachedFinishPoint()
    {
        SceneManager.LoadScene(0);
    }
}
