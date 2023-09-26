using UniRx;
using UnityEngine;

public class ProgressModel : MonoBehaviour
{
    ReactiveProperty<float> progress = new ReactiveProperty<float>(0);

    public IReadOnlyReactiveProperty<float> Progress => progress;

    float time = 0f;

    void Update()
    {
        if (time < 3f)
        {
            time += Time.deltaTime;
            return;
        }
        time = 0f;
        progress.Value = Random.Range(0f, 1f);
        Debug.Log($"Progress: {progress.Value}");
    }
}
