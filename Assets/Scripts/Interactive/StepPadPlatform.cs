using UnityEngine;

public class StepPadPlatform : MonoBehaviour
{
    [SerializeField] private Sprite _stepOnSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _bridge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PushableBlock>(out PushableBlock block))
        {
            _spriteRenderer.sprite = _stepOnSprite;
            _bridge.SetActive(true);
        }
    }
}
