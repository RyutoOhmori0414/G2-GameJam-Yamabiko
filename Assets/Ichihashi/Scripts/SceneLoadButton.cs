using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] int sceneIndex;

    void Start()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene(sceneIndex));
    }
}
