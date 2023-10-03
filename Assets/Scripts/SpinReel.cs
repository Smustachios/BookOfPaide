using UnityEngine;

/// <summary>
/// Spins reels in the game. Each reel has own component.
/// </summary>
public class SpinReel : MonoBehaviour
{
    [SerializeField] private int reelId;
    [SerializeField] private float teaseAmount = 54.0f;
    [SerializeField] private float bumpAmount = 3.0f;
    [SerializeField] private float preSpinLenght = 9.0f;
    [SerializeField] private float spinLenght = 9.0f;
    [SerializeField] private float spinSpeed = 100.0f;
    [SerializeField] private float preSpinSpeed = 100.0f;
    [SerializeField] private float bumpSpeed = 100.0f;

    private Transform _transform;
    private Vector3 _finalPos;
    private Vector3 _bumpPos;
    private Vector3 _startPos;
    private Vector3 _endPreSpinPos;
    private bool _preSpinActive = false;
    private bool _bumpActive = false;
    private bool _spinActive = false;
    private float _slowSpin = 0;
    private float _slowPreSpin = 0;
    private float _slowBump = 0;
    private float _actualSpinSpeed = 0;
    private float _actualPreSpinSpeed = 0;
    private float _actualBump = 0;
    private float _slowDivider = 0.75f;


    private void Awake()
    {
        _transform = transform;
        _slowSpin = spinSpeed * _slowDivider;
        _slowPreSpin = preSpinSpeed * _slowDivider;
        _slowBump = bumpSpeed * _slowDivider;
    }
    
    // Once reel reaches final pos, turn update off.
    private void Update()
    {
        if (_preSpinActive)
        {
            _transform.Translate(new Vector3(0, -0.5f) * _actualPreSpinSpeed * Time.deltaTime);

            if (!(_transform.position.y <= _endPreSpinPos.y)) return;
            
            _transform.position = _startPos;
            _bumpActive = true;
            _preSpinActive = false;
        }
        else if (_bumpActive)
        {
            _transform.Translate(new Vector3(0, -0.5f) * _actualSpinSpeed * Time.deltaTime);

            if (!(_transform.position.y <= _bumpPos.y)) return;
            
            _transform.position = _bumpPos;
            _spinActive = true;
            _bumpActive = false;
        }
        else if (_spinActive)
        {
            _transform.Translate(new Vector3(0, 0.25f) * _actualBump * Time.deltaTime);

            if (!(_transform.position.y >= _finalPos.y)) return;
            
            _transform.position = _finalPos;
            _spinActive = false;
            enabled = false;

            EventCenter.reelStop.Invoke(reelId);

            // Once last reel stops tell continue with the rest of the sequence.
            if (reelId == 5)
            {
                EventCenter.reelsStopped.Invoke();
            }
        }
    }

    // Start animation from here.
    public void StartSpin(SpinType spinType, int randomReelPos, int startTeaseReel)
    {
        _finalPos = new Vector3(_transform.position.x ,-randomReelPos * 3 + 3);
        _bumpPos = new Vector3(_transform.position.x, _finalPos.y - bumpAmount);
        SetStartPos(spinType, startTeaseReel);
        _endPreSpinPos = _transform.position - new Vector3(0, preSpinLenght);

        SetOrigSpinSpeed();

        _preSpinActive = true;
        enabled = true;
    }

    public void StopReel()
    {
        if (enabled)
        {
            _preSpinActive = false;

            _transform.position = _bumpPos;

            _spinActive = true;
            _bumpActive = false;
        }
    }

    // Change speed for tease anim
    public void SlowReelSpin()
    {
        _actualPreSpinSpeed = _slowPreSpin;
        _actualSpinSpeed = _slowSpin;
        _actualBump = _slowBump;
    }

    // Set spin speed
    private void SetOrigSpinSpeed()
    {
        _actualSpinSpeed = spinSpeed;
        _actualPreSpinSpeed = preSpinSpeed;
        _actualBump = bumpSpeed;
    }

    private void SetStartPos(SpinType spinType, int startTeaseReel)
    {
        if (spinType == SpinType.Normal)
        {
            _startPos = _finalPos + new Vector3(0, spinLenght);
        }
        else
        {
            if (reelId < startTeaseReel)
            {
                _startPos = _finalPos + new Vector3(0, spinLenght);
            }
            else
            {
                int teaseMultiplier = reelId - startTeaseReel + 1;
                _startPos = _finalPos + new Vector3(0, spinLenght + teaseAmount * teaseMultiplier);
            }
        }
    }
}
