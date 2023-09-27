using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip _hitBlockIceSE;
    [SerializeField] AudioClip _hitIceCreamSE;
    [SerializeField] AudioClip _dropIceCreamSE;
    [SerializeField] AudioClip _jumpSE;
    [SerializeField] AudioClip _buttonClickSE;
    AudioSource _audioSource;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void HitBlockIceSE() => _audioSource.PlayOneShot(_hitBlockIceSE);
    public void HitIceCreamSE() => _audioSource.PlayOneShot(_hitIceCreamSE);
    public void DropIceCreanSE() => _audioSource.PlayOneShot(_dropIceCreamSE);
    public void JumpSE() => _audioSource.PlayOneShot(_jumpSE);
    public void ButtonClickSE() => _audioSource.PlayOneShot(_buttonClickSE);
}
