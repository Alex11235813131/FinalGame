using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _deactivationDelay;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody.AddForce(Vector2.left * _speed);
        StartCoroutine(DeactivateObject());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(_deactivationDelay);
        gameObject.SetActive(false);
    }
}
