using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Make reels in the game.
/// </summary>
public class ReelManager : MonoBehaviour
{
    public ReelConstructor[] reelConstructors;
    public SpinReel[] reelSpinners;
    public ActiveSymbols[] reelActiveSymbols;
    public GameObject teaseReelAnim;
    public GameObject expandingReel;
    public SpriteMask baseReelMask;
    public SpriteMask expandingReelMask;

    private SpinData _spinData;
    private SpinType _spinType;


    // After each reel stops spinning, check if next reel needs to play tease anim.
    private void OnEnable()
    {
        EventCenter.reelStop += CheckTeaseAnim;
    }

    private void OnDisable()
    {
        EventCenter.reelStop -= CheckTeaseAnim;
    }

    // Spin all reels
    public void SpinReels(SpinData spinData, bool isTease)
    {
        _spinData = spinData;
        _spinType = isTease ? SpinType.Tease : SpinType.Normal;
        
        for (int i = 0; i < reelSpinners.Length; i++)
        {
            reelSpinners[i].StartSpin(_spinType, _spinData.RandomReelSpots[i], _spinData.StartTeaseReel);
        }
        
        SetUpActiveSymbols();
    }

    // Stop all reels instanly if player presses spin again while on the spin.
    public void StopReels()
    {
        for (int i = 0; i < reelSpinners.Length; i++)
        {
            reelSpinners[i].StopReel();
        }
    }
    
    // Set up active symbols.
    public void SetUpActiveSymbols()
    {
        for (int i = 0; i < _spinData.RandomReelSpots.Length; i++)
        {
            reelActiveSymbols[i].GetActiveSymbols(_spinData.RandomReelSpots[i]);
        }
    }

    // Get all books to move them in the center
    public List<BookBehaviour> GetActiveBooks()
    {
        List<BookBehaviour> allBooks = new List<BookBehaviour>();

        foreach (ActiveSymbols reelSymbols in reelActiveSymbols)
        {
            SymbolBehaviour symbol = reelSymbols.GetBookSymbol();

            if (symbol != null)
            {
                allBooks.Add(symbol.GetComponent<BookBehaviour>());
            }
        }

        return allBooks;
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

    // Play next reels tease anim if have to.
    private void CheckTeaseAnim(int reelId)
    {
        // Stop anim and continue with the spin sequence if last reel has stopped.
        if (reelId == 5)
        { 
            teaseReelAnim.SetActive(false);
            return;
        }

        if (_spinType != SpinType.Tease || reelId < _spinData.StartTeaseReel - 1)
        {
            return;
        }

        teaseReelAnim.transform.position = GetTeaseAnimPos(reelId + 1);
        teaseReelAnim.SetActive(true);
    }

    private Vector3 GetTeaseAnimPos(int reelId)
    {
        return reelId switch
        {
            3 => Vector3.zero,
            4 => new Vector3(3, 0),
            5 => new Vector3(6, 0),
            _ => Vector3.zero,
        };
    }
}
