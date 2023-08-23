using System;
using UnityEngine;


/// <summary>
/// Make reels in the game.
/// </summary>
public class ReelManager : MonoBehaviour
{
    public SpinReel[] reelSpinners;
    public ReelConstructor[] reelConstructors;
    public GameObject expandingReel;
    public SpriteMask baseReelMask;
    public SpriteMask expandingReelMask;

    private SpinData _spinData;

    
    // Spin all reels
    public void SpinReels(SpinData spinData)
    {
        _spinData = spinData;
        
        for (int i = 0; i < reelSpinners.Length; i++)
        {
            reelSpinners[i].StartSpin(SpinType.Normal, _spinData.RandomReelSpots[i]);
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

    // Change sprite masks for the duratation of the expanding reel spin animation.
    public void EnableFreespinMask()
    {
        baseReelMask.enabled = false;
        expandingReelMask.enabled = true;
    }

    public void DisableFreespinMask()
    {
        baseReelMask.enabled = true;
        expandingReelMask.enabled = false;
    }
}
