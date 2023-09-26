using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _enemyPos;
    [SerializeField] int _randmin = 0;
    [SerializeField] int _randmax = 0;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Spawn();
        }
    }

    private void Spawn ()
    {
        Instantiate(_enemyPrefab,new Vector2(_enemyPos.position.x, Random.Range(_randmin,_randmax)),Quaternion.identity);
    }
}
