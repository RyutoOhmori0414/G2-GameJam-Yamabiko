using UniRx;
using UnityEngine;

public class ProgressPresenter : MonoBehaviour
{
    // TODO: ステージから進行状況を取得する

    [SerializeField] ProgressModel progressModel;
    [SerializeField] ProgressView progressView;

    private void Start()
    {
        progressModel.Progress
            .Subscribe(value => progressView.SetProgress(value))
            .AddTo(this);
    }
}
