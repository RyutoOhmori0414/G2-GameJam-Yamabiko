using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] string _sceneName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
