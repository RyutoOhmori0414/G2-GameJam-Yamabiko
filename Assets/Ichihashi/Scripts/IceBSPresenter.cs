using UniRx;
using UnityEngine;

public class IceBSPresenter : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] IceBSView view;

    public PlayerController PlayerController
    {
        set
        {
            player = value;
            player.CurrentHpRP
                .Subscribe(hp => view.SetBSWeight((1 - hp / player.MaxHP) * 100));
        }
    }
}
