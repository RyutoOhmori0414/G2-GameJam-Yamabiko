using UniRx;
using UnityEngine;

public class HPPresenter : MonoBehaviour
{
    // TODO: プレイヤーからHPを取得する
    [SerializeField] HPModel hpModel;
    [SerializeField] HPView hpView;

    private void Start()
    {
        hpModel.HP
            .Subscribe(value => hpView.SetHP(value))
            .AddTo(this);
    }
}
