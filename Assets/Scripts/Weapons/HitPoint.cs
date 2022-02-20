using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    public int Damage => _damage;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(DelayBeforeDeactivation());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            enemy.TakeDamage(_damage);           
        else if (collision.gameObject.TryGetComponent<ProtectedShield>(out ProtectedShield shield))
            shield.ApplyDamage(_damage);
    }

    private IEnumerator DelayBeforeDeactivation()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
