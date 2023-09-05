using System;
using UnityEngine;


/// <summary>
/// Make reels in the game.
/// </summary>
public class ReelManager : MonoBehaviour
{
    public SpinReel[] reelSpinners;
    public ActiveSymbols[] reelActiveSymbols;
    public ReelConstructor[] reelConstructors;
    public GameObject expandingReel;
    public SpriteMask baseReelMask;
    public SpriteMask expandingReelMask;

    private SpinData _spinData;

    
    // Spin all reels
    public void SpinReels(SpinData spinData, bool isTease, int startTeaseReel)
    {
        _spinData = spinData;
        
        SpinType spinType = isTease ? SpinType.Tease : SpinType.Normal;
        
        for (int i = 0; i < reelSpinners.Length; i++)
        {
            reelSpinners[i].StartSpin(spinType, _spinData.RandomReelSpots[i], startTeaseReel);
        }
        
        SetUpActiveSymbols();
    }
    
    // Set up active symbols.
    public void SetUpActiveSymbols()
    {
        for (int i = 0; i < _spinData.RandomReelSpots.Length; i++)
        {
            reelActiveSymbols[i].GetActiveSymbols(_spinData.RandomReelSpots[i]);
        }
    }
    
    // Clears all 5 reels at the start of the freespins or at the end of the freespins.
    public void ClearReels()
    {
        foreach (ReelConstructor constructor in reelConstructors)
        {
            constructor.DestroyReel();
        }
    }

    public void MakeBaseReels(GameObject[] gameSymbols)
    {
        foreach (ReelConstructor constructor in reelConstructors)
        {
            constructor.MakeReel(gameSymbols, false);
        }
    }

    public void MakeBonusReels(GameObject[] gameSymbols)
    {
        foreach (ReelConstructor constructor in reelConstructors)
        {
            constructor.MakeReel(gameSymbols, true);
        }
    }

    public void MakeExpandingReel(GameObject[] gameSymbols)
    {
        expandingReel.GetComponent<ReelConstructor>().MakeExpandingReel(gameSymbols);
    }

    public void ClearExpandingReel()
    {
        ReelConstructor constructor = expandingReel.GetComponent<ReelConstructor>();
        constructor.DestroyReel();
    }

    // Change sprite masks for the duration of the expanding reel spin animation.
    public void EnableFreeSpinMask()
    {
        baseReelMask.enabled = false;
        expandingReelMask.enabled = true;
    }

    public void DisableFreeSpinMask()
    {
        baseReelMask.enabled = true;
        expandingReelMask.enabled = false;
    }
}
