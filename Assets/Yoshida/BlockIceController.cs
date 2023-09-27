using UnityEngine;

public class BlockIceController : MonoBehaviour
{
    /// <summary>�X�擾���̉񕜗�</summary>
    [SerializeField, Tooltip("�X�擾���̉񕜗�")] float _healValue;
    /// <summary>�X�擾���̑��x�㏸</summary>
    [SerializeField, Tooltip("�X�擾���̑��x�㏸")] float _speedUp;

    [SerializeField] private ParticleSystem _particleSystem = default;
    
    PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _playerController))
        {
            _playerController.HitBlockIce(_healValue, _speedUp);
            var temp = Instantiate(_particleSystem);
            temp.transform.position = other.transform.position;
            Destroy(this.gameObject);
        }
    }
}
