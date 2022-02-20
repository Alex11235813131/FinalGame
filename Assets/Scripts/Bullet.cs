using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _deacivationDelay;

    private Coroutine _coroutine;
    private Vector2 _moveDirection;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DeactivationDelay());
        _moveDirection = new Vector2(transform.localScale.x, 0);
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
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);

        gameObject.SetActive(false);
    }

    private IEnumerator DeactivationDelay()
    {
        yield return new WaitForSeconds(_deacivationDelay);
        gameObject.SetActive(false);
    }
}
