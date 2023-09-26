using UniRx;
using UnityEngine;

public class HPPresenter : MonoBehaviour
{
    // TODO: ƒvƒŒƒCƒ„[‚©‚çHP‚ðŽæ“¾‚·‚é
    [SerializeField] HPModel hpModel;
    [SerializeField] HPView hpView;

    private void Start()
    {
        hpModel.HP
            .Subscribe(value => hpView.SetHP(value))
            .AddTo(this);
    }
}
