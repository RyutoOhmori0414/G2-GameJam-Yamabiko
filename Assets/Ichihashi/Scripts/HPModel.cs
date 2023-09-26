using UniRx;
using UnityEngine;

public class HPModel : MonoBehaviour
{
    ReactiveProperty<float> hp = new ReactiveProperty<float>(100);
    public IReadOnlyReactiveProperty<float> HP => hp;

    float time = 0f;

    private void Update()
    {
        if (time < 3f)
        {
            time += Time.deltaTime;
            return;
        }
        time = 0f;
        hp.Value = Random.Range(0f, 1f);
        Debug.Log($"HP: {hp.Value}");
    }
}
