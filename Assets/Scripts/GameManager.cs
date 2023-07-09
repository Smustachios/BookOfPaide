using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ReelSpinner reelSpinner;
    public Freespins freespin;
    public ReelManager reelManager;
    public ExpandingSymbol expandingSymbolManager;
    public ShowLine lineAnimations;

    public GameObject[] gameSymbols;
    public GameObject payTable;
    public Action<List<LineHit>> ShowLines;
    public Symbol expandingSymbol;
    public int nOfFreespins = 10;
    public int freespinsLeft = 0;
    public bool spinCompleted = true;

    private BOPGamePlay gamePlay;
    private CoinManager coinManager;
    private SpinData spinData;
    private int freespinsPlayed = 0;
    private int totalFreespins = 0;

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
        reelSpinner.reelsStopped += FinishSpin;
    }

    private void OnDisable()
    {
        reelSpinner.reelsStopped -= FinishSpin;
    }

    // This method is called when player presses spin button.
    public void StartSpin()
    {
        if (spinCompleted && !expandingSymbolManager.expandingAnimationRunning && !freespin.freespinSequenceActivated)
        {
            spinCompleted = false; // Cant press spin button again.

            if (payTable.activeInHierarchy == true)
            {
                payTable.SetActive(false);
            }

            // Take money from player if base spin or decrease freespins if freespin.
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

            spinData = GetSpinData(); // Spin vitrual reels to get all the data.

            reelSpinner.SpinReels(spinData.RandomReelSpots); // Play spin animation.
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

    // Once last reel has stopped spinning, finish spinning sequence.
    private void FinishSpin()
    {
        StartCoroutine(FinishSpinCoroutine());
    }

    private IEnumerator FinishSpinCoroutine()
    {
        coinManager.GetLineWins(spinData);
        yield return lineAnimations.ActivateLines(spinData.LineHits);

        yield return CheckExpandingSymbol();
        FreespinCheck();

        if (!FreespinsActivated)
        {
            coinManager.GetTotalWin();
            coinManager.ClearWins();
        }

        spinCompleted = true;
    }

    // Show expanding symbols.
    private IEnumerator CheckExpandingSymbol()
    {
        if (FreespinsActivated && spinData.ExpandingSymbolHit)
        {
            yield return expandingSymbolManager.PlayExpandingSymbols(spinData.ExpandingSymbolRowID);
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
