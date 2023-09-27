using UniRx;
using UnityEngine;

public class IceBSPresenter : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] IceBSView view;

    void Awake()
    {
        player.CurrentHpRP
            .Subscribe(hp => view.SetBSWeight((1 - hp / player.MaxHP) * 100));
    }
}
