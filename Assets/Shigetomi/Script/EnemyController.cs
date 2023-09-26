using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 0f;
    private Rigidbody _enemyRb;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _enemyRb.AddForce(Vector3.left * _enemySpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("D");
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out HoldIceController iceCon))
        {
            collision.transform.root.GetComponent<PlayerController>().HitEnemy(iceCon.Index);
        }
    }
}
