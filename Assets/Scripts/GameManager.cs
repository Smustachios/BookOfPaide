using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ReelSpinner reelSpinner;
    public Freespins freespin;
    public ReelManager reelManager;
    public GameObject[] gameSymbols;
    public Action<List<LineHit>> ShowLines;
    public Symbol expandingSymbol;
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
            coinManager.uiStrings.GoodLuckText();
            spinCompleted = false;

            if (!FreespinsActivated)
            {
                coinManager.MakeBet();
            }
            else
            {
                freespinsLeft--;
            }

            spinData = GetSpinData();

            reelSpinner.SpinReels(spinData.RandomReelSpots);
        }
    }

    private void FinishSpin()
    {
        ShowLines.Invoke(spinData.LineHits);
        coinManager.GetLineWins(spinData);

        if (spinData.BonusGameWon)
        {
            if (!FreespinsActivated)
            {
                FreespinsActivated = true;
                expandingSymbol = spinData.ExpandingSymbol;
                freespin.StartFreespins(spinData.RandomExpaningReelSpot);
            }
            else
            {
                freespinsLeft += nOfFreespins;
            }
        }
        else
        {
            coinManager.GetTotalWin();
            coinManager.ClearWins();
        }

        spinCompleted = true;
    }

    private SpinData GetSpinData()
    {
        if (!FreespinsActivated)
        {
            spinData = gamePlay.Spin(FreespinsActivated, coinManager.NOfLines);

            return spinData;
        }
        else
        {
            spinData = gamePlay.Spin(FreespinsActivated, coinManager.NOfLines, expandingSymbol);

            return spinData;
        }
    }
}
