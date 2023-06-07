using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] gameSymbols;
    public GameObject[] reels;
    public Action<int[]> StartSpin;
    public Action<List<LineHit>> ShowLines;
    public Symbol expandingSymbol;

    public int nOfFreespins = 10;
    public int freespinsLeft = 0;

    public int nOfLines = 10;
    public decimal betPerLine = 1.0M;
    public decimal bankRoll = 1000.0M;

    private bool _freespinsActivated = false;
    public bool FreespinsActivated 
    {
        get
        {
            return _freespinsActivated;
        }
        set
        {
            _freespinsActivated = value;
            freespinsLeft = nOfFreespins;
        }
    }

    public bool betCompleted = false;
    public bool spinAnimCompleted = false;

    private BOPGamePlay gamePlay;
    private CoinManager coinManager;
    private SpinData spinData;
    

    private decimal spinWin = 0;
    private decimal totalWin = 0;

    private void Awake()
    {
        gamePlay = new();
        coinManager = new();

        coinManager.SetBankRoll(bankRoll);
    }

    public void SpinButton()
    {
        betCompleted = GetSpinData();
        PrintDebug(spinData);
        StartSpin.Invoke(spinData.RandomReelSpots);
        spinWin = 0;

        if (betCompleted)
        {
            coinManager.GetTotalWin(totalWin);
            PrintCoinDebug(totalWin);
            totalWin = 0;
        }
    }

    public bool GetSpinData()
    {
        if (!FreespinsActivated)
        {
            coinManager.MakeBet(nOfLines, betPerLine);

            spinData = gamePlay.Spin(FreespinsActivated, betPerLine, nOfLines);

            GetLineWins();

            if (spinData.BonusGameWon)
            {
                FreespinsActivated = true;
                freespinsLeft = nOfFreespins;
                expandingSymbol = spinData.ExpandingSymbol;
                Debug.Log($"Freespins won. Expanding symbol: {spinData.ExpandingSymbol}.");
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            freespinsLeft--;
            Debug.Log($"{freespinsLeft} freespins left.");

            spinData = gamePlay.Spin(FreespinsActivated, betPerLine, nOfLines, expandingSymbol);

            GetLineWins();

            if (spinData.BonusGameWon)
            {
                freespinsLeft += nOfFreespins;
                return false;
            }

            if (freespinsLeft <= 0)
            {
                FreespinsActivated = false;
                return true;
            }

            return false;
        }
    }

    private void GetLineWins()
    {
        foreach (LineHit hit in spinData.LineHits)
        {
            spinWin += coinManager.GetLineWin(hit.WinMultiplier);
        }

        if (spinData.ExpandingSymbolHit)
        {
            spinWin += coinManager.GetLineWin(spinData.ExpandingSymbolMultiplier) * nOfLines;
            Debug.Log($"Expanding symbol hit for {spinData.ExpandingSymbolWinID} symbols");
        }

        totalWin += spinWin;
    }

    private void ClearReels()
    {
        foreach (GameObject reel in reels)
        {
            ReelConstructor constructor = reel.GetComponent<ReelConstructor>();
            constructor.DestroyReel();
        }
    }

    private void MakeBonusReels()
    {
        foreach (GameObject reel in reels)
        {
            ReelConstructor constructor = reel.GetComponent<ReelConstructor>();
            constructor.MakeBonusReel();
        }
    }

    private void PrintDebug(SpinData spinData)
    {
        Debug.Log(spinData.ToString());

        foreach (string boardLine in spinData.boardStrings)
        {
            Debug.Log(boardLine + "\n");
        }
    }

    private void PrintCoinDebug(decimal totalWin)
    {
        Debug.Log($"totalWin: {totalWin}, bankroll: {coinManager.Bankroll}");
    }
}
