using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ProgressView : MonoBehaviour
{
    [SerializeField] Slider progressSlider;

    public Slider ProgressSlider => progressSlider;

    CancellationToken ct;

    void Start()
    {
        ct = this.GetCancellationTokenOnDestroy();
    }

    public async void SetProgress(float progress)
    {
        await progressSlider.DOValue(progress, 0.5f).WithCancellation(ct);
    }
}
