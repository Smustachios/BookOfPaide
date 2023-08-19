using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinReel : MonoBehaviour
{
    [SerializeField] private float preSpinLenght = 9.0f;
    
    private Vector3 _finalPos;
    private Vector3 _startPos;
    private Vector3 _endPreSpinPos;
    private bool _preSpinActive = false;
    private bool _spinActive = false;
    
    
    private void Update()
    {
        
    }

    public void StartSpin(SpinType spinType, int randomReelPos)
    {
        _finalPos = new Vector3(transform.position.x ,randomReelPos * 3);
    }
}
