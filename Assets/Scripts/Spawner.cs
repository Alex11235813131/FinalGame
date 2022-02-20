using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Chomper _chomper;
    [SerializeField] private Transform[] _chomperSpawnPoints;
    [SerializeField] private Player _target;

    private void Start()
    {
        InstantiateEnemy(_chomper, _chomperSpawnPoints);
    }

    private void InstantiateEnemy(Enemy prefab, Transform[] spawnPoints)
    {
        foreach (var point in spawnPoints)
        {
            var enemy = Instantiate(prefab, point.position, point.rotation).GetComponent<Chomper>();
            enemy.Init(_target);
        }       
    }
}
