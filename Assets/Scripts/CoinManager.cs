using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public UIStrings uiStrings;
    public decimal CoinsPerLine { get; private set; } = 1.0M;
    public int NOfLines { get; private set; } = 10;

    private decimal bankroll = 1000.0M;
    private decimal coins;
    private decimal coinValue = 0.1M;
    private decimal totalWin;
    private decimal spinWin;
    private decimal totalBet;


    private void Awake()
    {
        coins = bankroll / coinValue;
        totalBet = coinValue * CoinsPerLine * NOfLines;

        uiStrings.UpdateLineString(NOfLines);
        uiStrings.UpdateCoinsPerLineString(CoinsPerLine);
        uiStrings.UpdateCoinValueString(coinValue);
        uiStrings.UpdateCoinsString(coins);
        uiStrings.UpdateBetString(totalBet);
    }

    public bool MakeBet()
    {
        if (coins - (totalBet / coinValue) >= 0)
        {
            coins -= (totalBet / coinValue);
            bankroll -= totalBet * coinValue * NOfLines;
            Debug.Log(bankroll);
            uiStrings.UpdateCoinsString(coins);
            return true;
        }
        else
        {
            return false;
        }
    }

    public decimal GetLineWin(int multiplier)
    {
        return multiplier * CoinsPerLine;
    }

    public void GetTotalWin()
    {
        coins += totalWin;
        bankroll += totalWin * coinValue;
        Debug.Log(bankroll);
        uiStrings.UpdateCoinsString(coins);
    }

    public void ClearWins()
    {
        spinWin = 0;
        totalWin = 0;
    }

    public void GetLineWins(SpinData spinData)
    {
        foreach (LineHit hit in spinData.LineHits)
        {
            spinWin += GetLineWin(hit.WinMultiplier);
        }

        if (spinData.ExpandingSymbolHit)
        {
            spinWin += GetLineWin(spinData.ExpandingSymbolMultiplier) * NOfLines;
        }

        if (spinWin > 0)
        {
            uiStrings.UpdateSpinWinString(spinWin);
        }

        if (spinData.BookWinMultiplier > 0)
        {
            spinWin += spinData.BookWinMultiplier * coinValue;
        }

        totalWin += spinWin;
        spinWin = 0;
    }

    public void AddCoinValue()
    {
        if (coinValue < 1)
        {
            switch (coinValue)
            {
                case 0.01M:
                    coinValue = 0.02M;
                    break;
                case 0.02M:
                    coinValue = 0.03M;
                    break;
                case 0.03M:
                    coinValue = 0.04M;
                    break;
                case 0.04M:
                    coinValue = 0.05M;
                    break;
                case 0.05M:
                    coinValue = 0.1M;
                    break;
                case 0.1M:
                    coinValue = 0.2M;
                    break;
                case 0.2M:
                    coinValue = 0.5M;
                    break;
                case 0.5M:
                    coinValue = 1M;
                    break;
            }

            coins = bankroll / coinValue;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsString(coins);
            uiStrings.UpdateCoinValueString(coinValue);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    public void RemoveCoinValue()
    {
        if (coinValue > 0.01M)
        {
            switch (coinValue)
            {
                case 0.02M:
                    coinValue = 0.01M;
                    break;
                case 0.03M:
                    coinValue = 0.02M;
                    break;
                case 0.04M:
                    coinValue = 0.03M;
                    break;
                case 0.05M:
                    coinValue = 0.04M;
                    break;
                case 0.1M:
                    coinValue = 0.05M;
                    break;
                case 0.2M:
                    coinValue = 0.1M;
                    break;
                case 0.5M:
                    coinValue = 0.2M;
                    break;
                case 1M:
                    coinValue = 0.5M;
                    break;
            }

            coins = bankroll / coinValue;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsString(coins);
            uiStrings.UpdateCoinValueString(coinValue);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    public void AddCoinPerLine()
    {
        if (CoinsPerLine < 5)
        {
            CoinsPerLine++;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsPerLineString(CoinsPerLine);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    public void RemoveCoinPerLine()
    {
        if (CoinsPerLine > 1)
        {
            CoinsPerLine--;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsPerLineString(CoinsPerLine);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    public void AddLine()
    {
        if (NOfLines < 10)
        {
            NOfLines++;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateBetString(totalBet);
            uiStrings.UpdateLineString(NOfLines);
        }
    }

    public void RemoveLine()
    {
        if (NOfLines > 1)
        {
            NOfLines--;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateBetString(totalBet);
            uiStrings.UpdateLineString(NOfLines);
        }
    }
}
