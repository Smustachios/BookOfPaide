using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] gameSymbols;
    public int nOfFreespins = 10;
    public int freespinsLeft = 0;
    public int nOfLines = 10;
    public decimal betPerLine = 1.0M;
    public decimal bankRoll = 1000.0M;
    public bool freespinsActivated = false;
    public bool betCompleted = false;

    private BOPGamePlay gamePlay;
    private CoinManager coinManager;
    private SpinData spinData;
    private Symbol expandingSymbol;

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
        betCompleted = Spin();
        PrintDebug(spinData);
        spinWin = 0;

        if (betCompleted)
        {
            coinManager.GetTotalWin(totalWin);
            PrintCoinDebug(totalWin);
            totalWin = 0;
        }
    }

    public bool Spin()
    {
        if (!freespinsActivated)
        {
            coinManager.MakeBet(nOfLines, betPerLine);

            spinData = gamePlay.Spin(freespinsActivated, betPerLine, nOfLines);

            GetLineWins();

            if (spinData.BonusGameWon)
            {
                freespinsActivated = true;
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

            spinData = gamePlay.Spin(freespinsActivated, betPerLine, nOfLines, expandingSymbol);

            GetLineWins();

            if (spinData.BonusGameWon)
            {
                freespinsLeft += nOfFreespins;
                return false;
            }

            if (freespinsLeft <= 0)
            {
                freespinsActivated = false;
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
