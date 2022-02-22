using System.Collections;
using UnityEngine;

public class GolemBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private Vector2 _moveDirection;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DeactivatedDelay());
        _moveDirection = new Vector2(-transform.localScale.x, 0);
    }
    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivatedDelay()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
