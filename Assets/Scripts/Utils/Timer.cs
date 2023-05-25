using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    private float _time;
    private float _timer = 0f;
    public void SetTimer(float time)
    {
        _time = time;
    }

    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _time)
        {
            _timer = 0f;
        }
    }
    public bool IsReady()
    {
        return _timer == 0f;
    }
    
    public void Reset()
    {
        _timer = 0f;
    }
}