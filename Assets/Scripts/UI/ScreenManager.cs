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
        _player.Dying += OnPlayerDying;

        _finishGamePoint.Reached += OnFinishGamePointReached;

        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _startScreen.SettingButtonClick += OnSettingButtonClick;
        _startScreen.ExitButtonClick += OnExitButtonClick;

        _settingScreen.CloseScreenButtonDown += OnCloseScreenButtonDown;
        _settingScreen.RestartButtonClick += OnRestartButtonClick;
        _settingScreen.ExitButtonClick += OnExitButtonClick;

        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.SettingButtonClick += OnSettingButtonClick;
        _gameOverScreen.ExitButtonClick += OnExitButtonClick;

        _controllerScreen.SettingClick += OnSettingButtonClick;
    }

    private void OnDisable()
    {
        _player.Dying -= OnPlayerDying;
        _finishGamePoint.Reached -= OnFinishGamePointReached;

        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _startScreen.SettingButtonClick -= OnSettingButtonClick;
        _startScreen.ExitButtonClick -= OnExitButtonClick;

        _settingScreen.CloseScreenButtonDown -= OnCloseScreenButtonDown;
        _settingScreen.RestartButtonClick -= OnRestartButtonClick;
        _settingScreen.ExitButtonClick -= OnExitButtonClick;

        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.SettingButtonClick -= OnSettingButtonClick;
        _gameOverScreen.ExitButtonClick -= OnExitButtonClick;

        _controllerScreen.SettingClick -= OnSettingButtonClick;
    }

    private void Start()
    {
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _player.gameObject.SetActive(true);
        _startScreen.Close();
        _controllerScreen.Open();
        Time.timeScale = 1;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnSettingButtonClick()
    {
        Time.timeScale = 0;
        _controllerScreen.Close();
        _settingScreen.Open();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnPlayerDying()
    {
        _controllerScreen.Close();
        _gameOverScreen.Open();
    }

    private void OnCloseScreenButtonDown()
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

    private void OnFinishGamePointReached()
    {
        SceneManager.LoadScene(0);
    }
}
