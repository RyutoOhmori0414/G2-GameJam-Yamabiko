using UnityEngine;

public class BlockIceController : MonoBehaviour
{
    /// <summary>�X�擾���̉񕜗�</summary>
    [SerializeField, Tooltip("�X�擾���̉񕜗�")] float _healValue;
    /// <summary>�X�擾���̑��x�㏸</summary>
    [SerializeField, Tooltip("�X�擾���̑��x�㏸")] float _speedUp;
    PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _playerController))
        {
            _playerController.HitBlockIce(_healValue, _speedUp);
            Destroy(this.gameObject);
        }
    }
}
