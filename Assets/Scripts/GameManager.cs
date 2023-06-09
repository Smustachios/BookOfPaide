using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ReelSpinner reelSpinner;
    public ReelManager reelManager;
    public GameObject[] gameSymbols;
    public Action<List<LineHit>> ShowLines;
    public Symbol expandingSymbol;
    public int nOfLines = 10;
    public int nOfFreespins = 10;
    public int freespinsLeft = 0;

    private BOPGamePlay gamePlay;
    private CoinManager coinManager;
    private SpinData spinData;
    private bool spinCompleted = true;
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


    private void Awake()
    {
        gamePlay = new();
        coinManager = GetComponent<CoinManager>();

        reelManager.MakeBaseReels(gameSymbols);
    }

    private void OnEnable()
    {
        reelSpinner.reelsStopped += FinishSpin;
    }

    private void OnDisable()
    {
        reelSpinner.reelsStopped -= FinishSpin;
    }

    public void StartSpin()
    {
        if (spinCompleted)
        {
            spinCompleted = false;

            if (!FreespinsActivated)
            {
                coinManager.MakeBet(nOfLines);
            }
            else
            {
                freespinsLeft--;
            }

            spinData = GetSpinData();

            reelSpinner.SpinReels(spinData.RandomReelSpots);

            PrintDebug(spinData);
        }
    }

    private void FinishSpin()
    {
        ShowLines.Invoke(spinData.LineHits);
        coinManager.GetLineWins(spinData, nOfLines);

        if (spinData.BonusGameWon)
        {
            if (!FreespinsActivated)
            {
                FreespinsActivated = true;
                expandingSymbol = spinData.ExpandingSymbol;
                reelManager.ClearReels();
                reelManager.MakeBonusReels(gameSymbols);
            }
            else
            {
                freespinsLeft += nOfFreespins;
            }
        }
        else
        {
            coinManager.GetTotalWin();
            PrintCoinDebug(coinManager.TotalWin);
            coinManager.ClearWins();
        }

        spinCompleted = true;
    }

    private SpinData GetSpinData()
    {
        if (!FreespinsActivated)
        {
            spinData = gamePlay.Spin(FreespinsActivated, coinManager.BetPerLine, nOfLines);

            return spinData;
        }
        else
        {
            spinData = gamePlay.Spin(FreespinsActivated, coinManager.BetPerLine, nOfLines, expandingSymbol);

            return spinData;
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
