using System.Collections;
using UnityEngine;

public class GrenadeAttack : Attack
{
    [SerializeField] private Transform _grenadeSpawnPoint;
    [SerializeField] private float _animationDelay;
    [SerializeField] private ObjectPool _grenadePool;

    private const string _grenadeAttack = "GrenadeAttack";

    public override void Shoot()
    {
        _animator.SetTrigger(_grenadeAttack);

        if (_grenadePool.TryGetObject(out GameObject grenade))
        {
            StartCoroutine(SetGrenade(grenade));
        }
    }

    private IEnumerator SetGrenade(GameObject grenade)
    {
        yield return new WaitForSeconds(_animationDelay);
        grenade.SetActive(true);
        grenade.transform.position = _grenadeSpawnPoint.position;
    }
}
