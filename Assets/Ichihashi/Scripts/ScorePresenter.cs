using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;

    private void Awake()
    {
        scoreView.SetScore(ScoreManager.Score);
    }
}
