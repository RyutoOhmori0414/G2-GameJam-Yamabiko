using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public void SetScore(float score)
    {
        scoreText.text = "Score: " + ((int)score).ToString();
    }
}
