using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField, Range(1f, 2f)] float scaleSize = 1.1f;
    [SerializeField, Range(0f, 1f)] float scaleTime = 0.3f;

    CancellationToken ct;

    // Start is called before the first frame update
    void Start()
    {
        ct = this.GetCancellationTokenOnDestroy();
        TwitchButton();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            button.onClick.Invoke();
        }
    }

    async void TwitchButton()
    {
        while (true)
        {
            try
            {
                await button.transform.DOScale(scaleSize, scaleTime).SetLoops(-1, LoopType.Yoyo).WithCancellation(ct);
            }
            catch
            {
                Debug.Log("Button Twitching Stopped.");
                return;
            }
        }
    }
}
