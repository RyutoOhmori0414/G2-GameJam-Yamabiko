using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 0f;
    [SerializeField] private LayerMask _rayerMask = default;
    [SerializeField] private Transform _targetTransform = default;
    private Rigidbody _enemyRb;
    private bool _haveIce = false;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _enemyRb.AddForce(Vector3.left * _enemySpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        Debug.DrawLine(this.transform.position + new Vector3(0F, 0.5F, 0F), _targetTransform.position, Color.black);
        if (Physics.Linecast(this.transform.position + new Vector3(0F, 0.5F, 0F), _targetTransform.position, out RaycastHit hit, _rayerMask) && !_haveIce)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.transform.TryGetComponent(out HoldIceController iceController))
            {
                hit.collider.transform.root.GetComponent<PlayerController>().HitEnemy(iceController.Index);
                hit.collider.transform.SetParent(this.transform);
                _haveIce = true;
            }
        }
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
    }
}
