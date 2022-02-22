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
        _player.Dying += OnDie;
        _golem.Dying += OnDieGolem;
        _finishGamePoint.Reached += OnReachedFinishPoint;
        _bossActivator.Reached += OnReachedBossActivator;

        _startScreen.PlayButtonClicked += OnClick;
        _startScreen.SettingButtonClicked += OnClick;
        _startScreen.ExitButtonClicked += OnClick;

        _settingScreen.VolumeChanged += OnChangeVolume;
        _settingScreen.CloseScreenButtonClicked += OnClick;
        _settingScreen.RestartButtonClicked += OnClick;
        _settingScreen.ExitButtonClicked += OnClick;

        _gameOverScreen.RestartButtonClicked += OnClick;
        _gameOverScreen.SettingButtonClicked += OnClick;
        _gameOverScreen.ExitButtonClicked += OnClick;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDie;
        _finishGamePoint.Reached -= OnReachedFinishPoint;
        _bossActivator.Reached -= OnReachedBossActivator;

        _startScreen.PlayButtonClicked -= OnClick;
        _startScreen.SettingButtonClicked -= OnClick;
        _startScreen.ExitButtonClicked -= OnClick;

        _settingScreen.VolumeChanged -= OnChangeVolume;
        _settingScreen.CloseScreenButtonClicked -= OnClick;
        _settingScreen.RestartButtonClicked -= OnClick;
        _settingScreen.ExitButtonClicked -= OnClick;

        _gameOverScreen.RestartButtonClicked -= OnClick;
        _gameOverScreen.SettingButtonClicked -= OnClick;
        _gameOverScreen.ExitButtonClicked -= OnClick;
    }

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_ambiendSound);
        OnChangeVolume();
    }

    private void OnDie()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_playerDefeted);
    }

    public void OnChangeVolume()
    {
        _audioSource.volume = _volumeSlider.value;
    }

    private void OnClick()
    {
        _audioSource.PlayOneShot(_clickButtonSound, _clickVolume);
    }

    private void OnReachedFinishPoint()
    {
        Reset();
    }

    private void OnReachedBossActivator()
    {
        _audioSource.Stop();
        StartCoroutine(ChangeVolumeSmoothly(_bossFightVolume, _bossFigth));
    }

    private void OnDieGolem()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_bossDefeated);
        StartCoroutine(SetDelay(_ambiendDelay));
        _audioSource.PlayOneShot(_ambiendSound);
    }

    private IEnumerator ChangeVolumeSmoothly(float targetVolume, AudioClip audioClip)
    {
        _audioSource.volume = 0;
        _audioSource.PlayOneShot(audioClip);

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeStep * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator SetDelay(float delayCount)
    {
        yield return new WaitForSeconds(delayCount);
    }
}
