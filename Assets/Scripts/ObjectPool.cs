using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected Transform _container;
    [SerializeField] protected int _capacity;
    [SerializeField] private GameObject _prefab;

    private List<GameObject> _pool = new List<GameObject>();

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_prefab, _container, true);

            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == false)
                return result = item;
        }

        result = null;
        return false;
    }
}
