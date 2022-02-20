using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private BossActivator _bossActivator;
    [SerializeField] private Player _player;
    [SerializeField] private Golem _golem;
    [SerializeField] private FinishGamePoint _finishGamePoint;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private SettingScreen _settingScreen;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _ambiendSound;
    [SerializeField] private AudioClip _bossFigth;
    [SerializeField] private AudioClip _clickButtonSound;
    [SerializeField] private AudioClip _bossDefeated;
    [SerializeField] private AudioClip _playerDefeted;

    private float _volumeChangeStep = 0.1f;
    private float _clickVolume = 0.5f;
    private float _bossFightVolume = 0.2f;
    private float _ambiendDelay = 0.6f;

    private void OnEnable()
    {
        _player.Dying += OnPlayerDying;
        _golem.Dying += OnGolemDying;
        _finishGamePoint.Reached += OnFinishGamePointReached;
        _bossActivator.Reached += OnBossActivatorReached;

        _startScreen.PlayButtonClick += OnButtonDown;
        _startScreen.SettingButtonClick += OnButtonDown;
        _startScreen.ExitButtonClick += OnButtonDown;

        _settingScreen.VolumeChanged += OnVolumeChanged;
        _settingScreen.CloseScreenButtonDown += OnButtonDown;
        _settingScreen.RestartButtonClick += OnButtonDown;
        _settingScreen.ExitButtonClick += OnButtonDown;

        _gameOverScreen.RestartButtonClick += OnButtonDown;
        _gameOverScreen.SettingButtonClick += OnButtonDown;
        _gameOverScreen.ExitButtonClick += OnButtonDown;
    }

    private void OnDisable()
    {
        _player.Dying -= OnPlayerDying;
        _finishGamePoint.Reached -= OnFinishGamePointReached;
        _bossActivator.Reached -= OnBossActivatorReached;

        _startScreen.PlayButtonClick -= OnButtonDown;
        _startScreen.SettingButtonClick -= OnButtonDown;
        _startScreen.ExitButtonClick -= OnButtonDown;

        _settingScreen.VolumeChanged -= OnVolumeChanged;
        _settingScreen.CloseScreenButtonDown -= OnButtonDown;
        _settingScreen.RestartButtonClick -= OnButtonDown;
        _settingScreen.ExitButtonClick -= OnButtonDown;

        _gameOverScreen.RestartButtonClick -= OnButtonDown;
        _gameOverScreen.SettingButtonClick -= OnButtonDown;
        _gameOverScreen.ExitButtonClick -= OnButtonDown;
    }

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_ambiendSound);
        OnVolumeChanged();
    }

    private void OnPlayerDying()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_playerDefeted);
    }

    public void OnVolumeChanged()
    {
        _audioSource.volume = _volumeSlider.value;
    }

    private void OnButtonDown()
    {
        _audioSource.PlayOneShot(_clickButtonSound, _clickVolume);
    }

    private void OnFinishGamePointReached()
    {
        Reset();
    }

    private void OnBossActivatorReached()
    {
        _audioSource.Stop();
        StartCoroutine(SmoothlyVolumeUp(_bossFightVolume, _bossFigth));
    }

    private void OnGolemDying()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_bossDefeated);
        StartCoroutine(Delay(_ambiendDelay));
        _audioSource.PlayOneShot(_ambiendSound);
    }

    private IEnumerator SmoothlyVolumeUp(float targetVolume, AudioClip audioClip)
    {
        _audioSource.volume = 0;
        _audioSource.PlayOneShot(audioClip);

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeStep * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Delay(float delayCount)
    {
        yield return new WaitForSeconds(delayCount);
    }
}
