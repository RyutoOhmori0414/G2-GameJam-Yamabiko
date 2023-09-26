using UnityEngine;

public class IceCreamController : MonoBehaviour
{
    /// <summary>�v���C���[�̃Q�[���I�u�W�F�N�g�i�[�p</summary>
    [SerializeField, Tooltip("�v���C���[�̃Q�[���I�u�W�F�N�g������")] GameObject _player;
    PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _playerController))
        {
            _playerController.HitIceCream();
            this.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 3, _player.transform.position.z);
            this.transform.SetParent(_player.transform);
            Destroy(this.gameObject);
        }
    }
    public void IceTest()
    {
        this.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 1, _player.transform.position.z);
        this.transform.SetParent(_player.transform);
    }
}
