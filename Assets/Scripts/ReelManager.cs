using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelManager : MonoBehaviour
{
    public GameObject[] reels;
    public GameObject expandingReel;
    public SpriteMask baseReelMask;
    public SpriteMask expandingReelMask;


    public void ClearReels()
    {
        foreach (GameObject reel in reels)
        {
            ReelConstructor constructor = reel.GetComponent<ReelConstructor>();
            constructor.DestroyReel();
        }
    }

    public void MakeBaseReels(GameObject[] gameSymbols)
    {
        foreach (GameObject reel in reels)
        {
            reel.GetComponent<ReelConstructor>().MakeBaseReel(gameSymbols);
        }
    }

    public void MakeBonusReels(GameObject[] gameSymbols)
    {
        foreach (GameObject reel in reels)
        {
            ReelConstructor constructor = reel.GetComponent<ReelConstructor>();
            constructor.MakeBonusReel(gameSymbols);
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
