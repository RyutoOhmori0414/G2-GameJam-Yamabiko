using UniRx;
using UnityEngine;

public class HPPresenter : MonoBehaviour
{
    // TODO: ƒvƒŒƒCƒ„[‚©‚çHP‚ðŽæ“¾‚·‚é
    [SerializeField] PlayerController playerController;
    [SerializeField] HPModel hpModel;
    [SerializeField] HPView hpView;

    private void Start()
    {
        playerController.CurrentHpRP
            .Subscribe(value => hpView.SetHP(value / playerController.MaxHP))
            .AddTo(this);
        //hpModel.HP
        //    .Subscribe(value => hpView.SetHP(value))
        //    .AddTo(this);
    }
}
