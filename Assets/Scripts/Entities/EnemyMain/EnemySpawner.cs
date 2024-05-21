using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    void Start()
    {
        GameObject newEnemy = GameObject.Instantiate(enemy.gameObject, transform);
        newEnemy.transform.position = gameObject.transform.position;
    }
}
