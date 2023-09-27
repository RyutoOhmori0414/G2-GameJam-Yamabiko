using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] ScoreManager _scoreManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _scoreManager.CalcScore(true);
            SceneManager.LoadScene(_sceneName);
        }
    }
}
