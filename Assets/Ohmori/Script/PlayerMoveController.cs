using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField, Tooltip("現在の最高速")] private float _currentMaxSpeed = 10F;
    [SerializeField, Tooltip("最高速に達する時間")] private float _maxSpeedTime = 1.0F;
    private float _timer = 0.0F;
    private bool _isRunning = false;

    private Rigidbody _rb = default;

    
    
    private void FixedUpdate()
    {
        
    }
    
    
}
