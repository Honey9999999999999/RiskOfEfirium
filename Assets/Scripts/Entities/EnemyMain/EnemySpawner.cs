using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> _spawnPoints = new();
    [SerializeField] Enemy enemy;
    void Start()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            GameObject newEnemy = GameObject.Instantiate(enemy.gameObject, transform);
            newEnemy.transform.position = spawnPoint.position;
        }
    }
}
