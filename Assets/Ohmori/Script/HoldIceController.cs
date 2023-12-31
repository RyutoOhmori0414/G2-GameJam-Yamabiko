using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class HoldIceController : MonoBehaviour
{
    [SerializeField] private IceBSPresenter _presenter = default;
    [SerializeField, Tooltip("詰める際の速度")] private float _duration = 0.5F;
    /// <summary>このオブジェクトのインデックス</summary>
    private int _index = 0;
    
    private bool _isMoveing = false;

    private Transform _lastTarget = default;
    private TweenerCore<Vector3, Vector3, VectorOptions> _callback = default;

    public int Index
    {
        get => _index;
        set => _index = value;
    }

    public void SetPlayerController(PlayerController playerController)
    {
        _presenter.PlayerController = playerController;
    }
    public void IndexDecriment(Transform targetTransform)
    {
        if (_isMoveing)
        {
            _callback.Kill();
            transform.position = _lastTarget.position;
            this.transform.SetParent(targetTransform);
            _isMoveing = false;
        }
        _index--;
        _isMoveing = true;
        _lastTarget = targetTransform;
        
        Debug.Log($"{(targetTransform.position - transform.position).ToString()}");
        
        _callback = transform.DOLocalMove(targetTransform.position - transform.position, _duration).OnComplete(() =>
        {
            _isMoveing = false;
            this.transform.SetParent(targetTransform);
        });
    }
}
