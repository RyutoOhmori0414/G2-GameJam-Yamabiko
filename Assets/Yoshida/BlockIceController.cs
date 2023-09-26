using UnityEngine;

public class BlockIceController : MonoBehaviour
{
    /// <summary>•Xæ“¾‚Ì‰ñ•œ—Ê</summary>
    [SerializeField, Tooltip("•Xæ“¾‚Ì‰ñ•œ—Ê")] float _healValue;
    /// <summary>•Xæ“¾‚Ì‘¬“xã¸</summary>
    [SerializeField, Tooltip("•Xæ“¾‚Ì‘¬“xã¸")] float _speedUp;
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
