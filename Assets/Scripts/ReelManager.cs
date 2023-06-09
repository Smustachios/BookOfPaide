using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelManager : MonoBehaviour
{
    public GameObject[] reels;


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
}
