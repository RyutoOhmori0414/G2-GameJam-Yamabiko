using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip _hitBlockIceSE;
    [SerializeField] AudioClip _hitIceCreamSE;
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void HitBlockIceSE() => _audioSource.PlayOneShot(_hitBlockIceSE);
    public void HitIceCreamSE() => _audioSource.PlayOneShot(_hitIceCreamSE);
}
