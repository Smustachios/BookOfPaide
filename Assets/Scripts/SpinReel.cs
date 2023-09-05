using UnityEngine;

/// <summary>
/// Spins reels in the game. Each reel has own component.
/// </summary>
public class SpinReel : MonoBehaviour
{
    [SerializeField] private int reelId;
    [SerializeField] private float teaseAmount = 54;
    [SerializeField] private float preSpinLenght = 9.0f;
    [SerializeField] private float spinLenght = 9.0f;
    [SerializeField] private float spinSpeed = 100;

    private Transform _transform;
    private Vector3 _finalPos;
    private Vector3 _bumpPos;
    private Vector3 _startPos;
    private Vector3 _endPreSpinPos;
    private bool _preSpinActive = false;
    private bool _bumpActive = false;
    private bool _spinActive = false;


    private void Awake()
    {
        _transform = transform;
    }
    
    // Once reel reaches final pos, turn update off.
    private void Update()
    {
        if (_preSpinActive)
        {
            _transform.Translate(new Vector3(0, -0.5f) * spinSpeed * Time.deltaTime);

            if (!(_transform.position.y <= _endPreSpinPos.y)) return;
            
            _transform.position = _startPos;
            _bumpActive = true;
            _preSpinActive = false;
        }
        else if (_bumpActive)
        {
            _transform.Translate(new Vector3(0, -0.5f) * spinSpeed * Time.deltaTime);

            if (!(_transform.position.y <= _bumpPos.y)) return;
            
            _transform.position = _bumpPos;
            _spinActive = true;
            _bumpActive = false;
        }
        else if (_spinActive)
        {
            _transform.Translate(new Vector3(0, 0.25f) * spinSpeed * Time.deltaTime);

            if (!(_transform.position.y >= _finalPos.y)) return;
            
            _transform.position = _finalPos;
            _spinActive = false;
            enabled = false;

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
        _bumpPos = new Vector3(_transform.position.x, _finalPos.y - 3f);
        SetStartPos(spinType, startTeaseReel);
        _endPreSpinPos = _transform.position - new Vector3(0, preSpinLenght);

        _preSpinActive = true;
        enabled = true;
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
