using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpinType { Normal, Tease }

/// <summary>
/// Manages game flow.
/// </summary>
public class GameManager : MonoBehaviour
{
    public ReelSpinner reelSpinner;
    public Freespins freespin;
    public ReelManager reelManager;
    public ExpandingSymbol expandingSymbolManager;
    public ShowLine lineAnimations;
    public AutoSpin autoSpin;

    public GameObject[] gameSymbols;
    public GameObject payTable;
    public Symbol expandingSymbol;
    public int nOfFreespins = 10;
    public int freespinsLeft = 0;
    public bool spinCompleted = true;

    private BOPGamePlay gamePlay;
    private CoinManager coinManager;
    private SpinData spinData;
    private int freespinsPlayed = 0;
    private int totalFreespins = 0;
    private bool reelStopped = false;

    private bool _freespinsActivated = false;
    public bool FreespinsActivated
    {
        get
        {
            return _freespinsActivated;
        }
        private set
        {
            _freespinsActivated = value;

            if (value == true)
            {
                freespinsLeft = nOfFreespins; // Give player freespins at the start of bonus.
                totalFreespins += nOfFreespins;
                autoSpin.NOfAutoSpins = 0;
            }
            else
            {
                // Set and show congratz text at the end of the freespins.
                coinManager.uiStrings.UpdateCongratsString(coinManager.TotalWin, freespinsPlayed);
                freespin.FinishFreespins(coinManager.uiStrings.congratsString);
                totalFreespins = 0;
            }
        }
    }


    private void Awake()
    {
        gamePlay = new();
        coinManager = GetComponent<CoinManager>();

        reelManager.MakeBaseReels(gameSymbols);
    }

    private void OnEnable()
    {
        // Once last reel has stopped spinning it will notify here to continue with the spin sequence.
        EventCenter.reelsStopped += ShowWinLines;
        EventCenter.linesStopped += FinishSpin;
    }

    private void OnDisable()
    {
        EventCenter.reelsStopped -= ShowWinLines;
        EventCenter.linesStopped -= FinishSpin;
    }

    // This method is called when player presses spin button.
    public void StartSpin()
    {
        // If player presses spin while reels are running stop reels instanly.
        if (!spinCompleted)
        {
            if (!reelStopped)
            {
                reelManager.StopReels();
                reelStopped = true;
            }
            // If spin is pressed again after reels already stopped and game is showing win lines, finish showing current line and skip the rest.
            else if (!lineAnimations.linesStopped)
            {
                lineAnimations.linesStopped = true;
            }
        }

        if (spinCompleted && !expandingSymbolManager.expandingAnimationRunning && !freespin.freespinSequenceActivated)
        {
            spinCompleted = false; // So cant do double spin on the reels.
            reelStopped = false;
            autoSpin.spinActive = true;

            spinData = GetSpinData(); // Spin virtual reels to get all the data.

            if (payTable.activeInHierarchy)
            {
                payTable.SetActive(false);
            }

            // Take money from player if base spin or decrease free spins if free spin.
            if (!FreespinsActivated)
            {
                coinManager.MakeBet();
                coinManager.uiStrings.GoodLuckText();
            }
            else
            {
                freespinsPlayed++;
                freespinsLeft--;
                coinManager.uiStrings.UpdateFreespinsLeft(freespinsLeft, totalFreespins);
            }

            // reelSpinner.SpinReels(spinData.RandomReelSpots); // Play spin animation.
            reelManager.SpinReels(spinData, spinData.IsTease);
        }
    }

    // Once last reel has stopped spinning, finish spinning sequence.
    private void ShowWinLines()
    {
        reelStopped = true; // Set reels stopped so player can skip showing lines.

        coinManager.GetLineWins(spinData);
        lineAnimations.ActivateLines(spinData.LineHits, reelManager.reelActiveSymbols);
    }

    public void FinishSpin()
    {
        CheckExpandingSymbol();
        FreespinCheck();

        if (!FreespinsActivated)
        {
            coinManager.GetTotalWin();
            coinManager.ClearWins();
        }

        spinCompleted = true;
        autoSpin.spinActive = false;
    }

    // Move all book symbols in the middle before start book opening anim.
    public void CollectBooks()
    {
        foreach (BookBehaviour book in reelManager.GetActiveBooks())
        {
            book.StartBookMovement();
        }
    }

    // Show expanding symbols.
    private void CheckExpandingSymbol()
    {
        if (FreespinsActivated && spinData.ExpandingSymbolHit)
        {
            expandingSymbolManager.PlayExpandingSymbols(spinData.ExpandingSymbolRowID);
        }
    }

    // Freespins checks.
    private void FreespinCheck()
    {
        CheckStartOfFreespins();
        CheckEndOfFreespins();
    }

    // Check and activate freespins.
    private void CheckStartOfFreespins()
    {
        if (spinData.BonusGameWon)
        {
            if (!FreespinsActivated)
            {
                FreespinsActivated = true;
                coinManager.uiStrings.UpdateFreespinsLeft(freespinsLeft, totalFreespins);
                expandingSymbol = spinData.ExpandingSymbol;
                expandingSymbolManager.GetExpandingSymbol(expandingSymbol);
                StartCoroutine(freespin.StartFreespins(spinData.RandomExpaningReelSpot));
            }
            else
            {
                freespinsLeft += nOfFreespins;
                totalFreespins += nOfFreespins;
                StartCoroutine(freespin.ShowRetriggerMessage());
            }
        }
    }

    // Check if finished freespins.
    private void CheckEndOfFreespins()
    {
        if (freespinsLeft <= 0 && FreespinsActivated)
        {
            FreespinsActivated = false;
            coinManager.uiStrings.UpdateFreespinsLeft(freespinsLeft, totalFreespins);
            freespinsPlayed = 0;
        }
    }

    public void ShowPaytable()
    {
        if (spinCompleted && !expandingSymbolManager.expandingAnimationRunning && !freespin.freespinSequenceActivated)
        {
            payTable.SetActive(true);
        }
    }

    public void ClosePaytable()
    {
        if (payTable.activeInHierarchy)
        {
            payTable.SetActive(false);
        }
    }

    // Spins virtual reels to get data according to if its base or free spin.
    private SpinData GetSpinData()
    {
        if (!FreespinsActivated)
        {
            return gamePlay.Spin(FreespinsActivated, coinManager.NOfLines);
        }
        else
        {
            return gamePlay.Spin(FreespinsActivated, coinManager.NOfLines, expandingSymbol);
        }
    }
}
