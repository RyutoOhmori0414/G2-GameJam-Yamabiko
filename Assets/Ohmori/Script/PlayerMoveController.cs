using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField, Tooltip("現在の最高速")] private float _currentMaxSpeed = 10F;
    [SerializeField, Tooltip("最高速に達する時間")] private float _maxSpeedTime = 1.0F;
    [SerializeField, Tooltip("JumpPower")] private float _jumpPower = 5.0F;
    [SerializeField, Tooltip("着地エフェクト")] private ParticleSystem _onGroundEffect = default;
    [SerializeField] private DecalProjector _decal = default;
    private PlayerMoveState _state = PlayerMoveState.Stop;

    private Rigidbody _rb = default;

    private int _jumpCount = 2;
    
    private void FixedUpdate()
    {
        if (_state == PlayerMoveState.Running)
        {
            _rb.velocity = new Vector3(_currentMaxSpeed, _rb.velocity.y, _rb.velocity.z);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _jumpCount > 0)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _jumpCount--;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        PlayerStart();
    }

    public void AddSpeed(float addSpeed)
    {
        _currentMaxSpeed += addSpeed;
        PlayerStart();
    }

    public void PlayerStart()
    {
        _state = PlayerMoveState.Acceleration;
        // 現在のスピードから最高速まで持っていてくれる
        DOTween.To(
            () => _rb.velocity.x,
            x => _rb.velocity = new Vector3(x, _rb.velocity.y, _rb.velocity.z),
            _currentMaxSpeed,
            _maxSpeedTime
            ).OnComplete(() => _state = PlayerMoveState.Running);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (_jumpCount < 2)
            {
                var temp = Instantiate(_onGroundEffect);
                temp.transform.position = other.contacts[0].point;
                var temp2 = Instantiate(_decal);
                temp2.transform.position = other.contacts[0].point;
            }
            
            _jumpCount = 2;
        }
    }

    private enum PlayerMoveState
    {
        Stop,
        Acceleration,
        Running
    }
}
