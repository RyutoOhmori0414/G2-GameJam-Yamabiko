using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HPView : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    public Slider HPSlider => hpSlider;

    CancellationToken ct;

    void Start()
    {
        ct = this.GetCancellationTokenOnDestroy();
    }

    public async void SetHP(float hp)
    {
        await hpSlider.DOValue(hp, 0.5f).WithCancellation(ct);
    }
}
