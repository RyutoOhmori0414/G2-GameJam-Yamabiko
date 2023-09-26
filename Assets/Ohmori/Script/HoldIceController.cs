using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class HoldIceController : MonoBehaviour
{
    [SerializeField, Tooltip("詰める際の速度")] private float _duration = 0.5F;
    /// <summary>このオブジェクトのインデックス</summary>
    private int _index = 0;

    private bool _isMoveing = false;

    private Vector3 _lastTarget = Vector3.zero;
    private TweenerCore<Vector3, Vector3, VectorOptions> _callback = default;

    public int Index
    {
        get => _index;
        set => _index = value;
    }

    public void IndexDecriment(Vector3 moveTarget)
    {
        if (_isMoveing)
        {
            _callback.Kill();
            transform.position = _lastTarget;
            _isMoveing = false;
        }
        _index--;
        _isMoveing = true;
        _lastTarget = moveTarget;
        _callback = transform.DOLocalMove(moveTarget - transform.position, _duration).OnComplete(() => _isMoveing = false);
    }
}
