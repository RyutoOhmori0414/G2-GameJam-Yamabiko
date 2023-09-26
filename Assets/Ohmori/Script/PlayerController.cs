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
    
    /// <summary>現在のHP</summary>
    private ReactiveProperty<float> _currentHpRP = new ReactiveProperty<float>();

    /// <summary>げんざいのHPの変化を受け取るReactiveProperty</summary>
    public IReadOnlyReactiveProperty<float> CurrentHpRP => _currentHpRP;

    private PlayerMoveController _moveController = default;
    
    public void HitBlockIce(float _healValue, float _addSpeed)
    {
        
    }
    
    public void HitIceCream()
    {}

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
