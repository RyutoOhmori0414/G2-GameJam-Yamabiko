using UniRx;
using UnityEngine;

public class ProgressPresenter : MonoBehaviour
{
    // TODO: �X�e�[�W����i�s�󋵂��擾����

    [SerializeField] ProgressModel progressModel;
    [SerializeField] ProgressView progressView;

    private void Start()
    {
        progressModel.Progress
            .Subscribe(value => progressView.SetProgress(value))
            .AddTo(this);
    }
}
