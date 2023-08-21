using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinReel : MonoBehaviour
{
    [SerializeField] private int reelId;
    [SerializeField] private float preSpinLenght = 9.0f;
    [SerializeField] private float spinLenght = 9.0f;
    [SerializeField] private float spinSpeed = 100;

    private Transform _transform;
    private Vector3 _finalPos;
    private Vector3 _startPos;
    private Vector3 _endPreSpinPos;
    private bool _preSpinActive = false;
    private bool _spinActive = false;


    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_preSpinActive)
        {
            _transform.Translate(new Vector3(0, -0.25f) * spinSpeed * Time.deltaTime);

            if (_transform.position.y <= _endPreSpinPos.y)
            {
                _transform.position = _startPos;
                _spinActive = true;
                _preSpinActive = false;
            }
        }
        else if (_spinActive)
        {
            _transform.Translate(new Vector3(0, -0.25f) * spinSpeed * Time.deltaTime);
            
            if (_transform.position.y <= _finalPos.y)
            {
                _transform.position = _finalPos;
                _spinActive = false;
                enabled = false;

                if (reelId == 5)
                {
                    EventCenter.reelsStopped.Invoke();
                }
            }
        }
    }

    public void StartSpin(SpinType spinType, int randomReelPos)
    {
        _finalPos = new Vector3(transform.position.x ,-randomReelPos * 3 + 3);
        _startPos = _finalPos + new Vector3(0, spinLenght);
        _endPreSpinPos = _transform.position - new Vector3(0, preSpinLenght);

        _preSpinActive = true;
        enabled = true;
    }
}
