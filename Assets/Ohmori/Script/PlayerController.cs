using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("MaxHp")] private float _maxHP = 100.0F;
    
    [SerializeField, Tooltip("何秒でHPが0になるか(何もしなかった際)")]
    private float _slipDamage = 30.0F;

    [SerializeField, Tooltip("アイスを積み重ねるPosition")]
    private Transform[] _iceHoldPositions = default;

    [SerializeField, Tooltip("積み重ねるIceのPrefab")]
    private HoldIceController _icePrefab = default;
    
    /// <summary>現在のHP</summary>
    private ReactiveProperty<float> _currentHpRP = new ReactiveProperty<float>();

    /// <summary>げんざいのHPの変化を受け取るReactiveProperty</summary>
    public IReadOnlyReactiveProperty<float> CurrentHpRP => _currentHpRP;

    private PlayerMoveController _moveController = default;
    private List<HoldIceController> _iceControllers = new List<HoldIceController>();
    private int _currentIceIndex = 0;
    
    public void HitBlockIce(float healValue, float addSpeed)
    {
        // HPの更新
        _currentHpRP.Value = Mathf.Clamp(_currentHpRP.Value + healValue, 0, _maxHP);
        
        // スピードの更新
        _moveController.AddSpeed(addSpeed);
    }

    public void HitIceCream()
    {
        var temp = Instantiate(_icePrefab);
        temp.transform.position = _iceHoldPositions[_currentIceIndex].position;
        _iceControllers.Add(temp);
        temp.Index = _currentIceIndex;
        _currentIceIndex++;
    }

    public void HitEnemy(int removeIndex)
    {
        var temp = _iceControllers[removeIndex];
        _iceControllers.RemoveAt(removeIndex);

        for (int i = removeIndex; i < _iceControllers.Count; i++)
        {
            _iceControllers[i].IndexDecriment(_iceHoldPositions[i].position);
        }

        _currentIceIndex--;
    }

    private void Awake()
    {
        _currentHpRP.Value = _maxHP;
        _moveController = GetComponent<PlayerMoveController>();
    }

    private void Update()
    {
        // スリップダメージ
        _currentHpRP.Value -= _maxHP / _slipDamage * Time.deltaTime;
    }
}

/// <summary>Itemの種類</summary>
public enum ItemType
{
    IceCream,
    BlockIce
}
