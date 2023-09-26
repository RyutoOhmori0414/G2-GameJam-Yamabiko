using UniRx;
using UnityEngine;

public class HPPresenter : MonoBehaviour
{
    // TODO: �v���C���[����HP���擾����
    [SerializeField] HPModel hpModel;
    [SerializeField] HPView hpView;

    private void Start()
    {
        hpModel.HP
            .Subscribe(value => hpView.SetHP(value))
            .AddTo(this);
    }
}
