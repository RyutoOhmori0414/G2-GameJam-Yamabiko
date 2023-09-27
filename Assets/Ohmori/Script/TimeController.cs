using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float _timer = 0.0F;

    /// <summary>現在の経過時間</summary>
    public float CurrentTime => _timer;

    private bool _running = false;

    public void StartTimer()
    {
        _running = true;
    }

    private void Update()
    {
        if (_running)
        {
            _timer += Time.deltaTime;
        }
    }
}
