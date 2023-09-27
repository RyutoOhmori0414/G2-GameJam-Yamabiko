using UniRx;
using UnityEngine;

public class ProgressModel : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] StageMater stage;

    ReactiveProperty<float> progress = new ReactiveProperty<float>(0);

    public IReadOnlyReactiveProperty<float> Progress => progress;

    void Update()
    {
        var playerPosition = player.transform.position.x - stage.StartPoint.position.x;
        var progressValue = playerPosition / stage.PointDifferrence;
        progress.Value = progressValue;
    }
}
