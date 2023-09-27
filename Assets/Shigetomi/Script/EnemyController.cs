using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 0f;
    [SerializeField] private LayerMask _rayerMask = default;
    [SerializeField] private Transform _targetTransform = default;
    [SerializeField] private Vector3 _rayStartPosDiff = Vector3.zero;
    [SerializeField] private ParticleSystem _getEffect = default;
    private Rigidbody _enemyRb;
    private bool _haveIce = false;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _enemyRb.AddForce(Vector3.left * _enemySpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        Debug.DrawLine(this.transform.position + _rayStartPosDiff, _targetTransform.position, Color.black);
        if (Physics.Linecast(this.transform.position + _rayStartPosDiff, _targetTransform.position, out RaycastHit hit, _rayerMask) && !_haveIce)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.transform.TryGetComponent(out HoldIceController iceController))
            {
                var temp = Instantiate(_getEffect);
                temp.transform.position = hit.collider.transform.position;
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

        if (collision.gameObject.tag == "BackWall")
        {
            Destroy(this.gameObject);
        }
    }
}
