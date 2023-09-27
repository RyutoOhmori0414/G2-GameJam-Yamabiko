using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField, Tooltip("体力1あたりのスコア")]
    private int _hpScore = 20;

    [SerializeField, Tooltip("アイス一つあたりのスコア")]
    private int _iceCreamScore = 150;

    [SerializeField, Tooltip("ゴールする基準タイム(減点にならない最大の時間)")]
    private float _goalTimeStanderd = 60.0F;

    [SerializeField, Tooltip("タイムボーナスの最大点")]
    private int _timeScore = 1000;
    
    [SerializeField] private PlayerController _playerController = default;
    [SerializeField] private TimeController _timeController = default;
    
    private static float _score = 0;
    
    /// <summary>現在のスコア(呼び出すとスコアの初期化を行います)</summary>
    public static float Score
    {
        get
        {
            var temp = _score;
            _score = 0.0F;
            return temp;
        }
    }

    /// <summary>スコアを計算する(ゲーム終了時に呼び出し)</summary>
    public void CalcScore(bool isClear)
    {
        _score += _playerController.CurrentHpRP.Value * _hpScore;
        _score += _playerController.CurrentIceCount * _iceCreamScore;
        if (isClear)
        {
            _score += (1 - _timeController.CurrentTime / _goalTimeStanderd) * _timeScore;
        }
    }
}
