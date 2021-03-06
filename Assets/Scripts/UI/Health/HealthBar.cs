using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartPrefab;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int heartCountCreated = value - _hearts.Count;

            for (int i = 0; i < heartCountCreated; i++)
            {
                CreateHeart();
            }
        }
        else if(_hearts.Count > value)
        {
            int heartCount = _hearts.Count - value;

            for (int i = 0; i < heartCount; i++)
            {
                RemoveHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void RemoveHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.Deactivate();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab, transform);
        _hearts.Add(newHeart);
    }
}
