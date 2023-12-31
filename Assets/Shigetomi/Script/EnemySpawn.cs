using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _enemyPos;
    [SerializeField] int _randmin = 0;
    [SerializeField] int _randmax = 0;

    private void Update()
    {
       // Spawn();
    }

    public void Spawn()
    {
        Instantiate(_enemyPrefab, new Vector2(_enemyPos.position.x, Random.Range(_randmin, _randmax)), Quaternion.identity);
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.tag == "SpwanPoint")
    //    {
    //        Instantiate(_enemyPrefab, new Vector2(_enemyPos.position.x, Random.Range(_randmin, _randmax)), Quaternion.identity);
    //    }
    //}
}
