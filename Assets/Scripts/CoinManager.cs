using UnityEngine;

/// <summary>
/// Manage everything with betting and betting UI elements.
/// </summary>
public class CoinManager : MonoBehaviour
{
    public UIStrings uiStrings;
    public GameManager gameManager;
    public decimal CoinsPerLine { get; private set; } = 1.0M;
    public int NOfLines { get; private set; } = 10;
    public decimal TotalWin { get; private set; } // In coins

    private decimal bankroll = 1000.0M;
    private decimal coinValue = 0.1M;
    private decimal coins; // Is bankroll / coin value
    private decimal spinWin; // In coins
    private decimal totalBet; // In fiat


    private void Awake()
    {
        // Update UI at the start of the game.
        coins = bankroll / coinValue;
        totalBet = coinValue * CoinsPerLine * NOfLines;

        uiStrings.UpdateLineString(NOfLines);
        uiStrings.UpdateCoinsPerLineString(CoinsPerLine);
        uiStrings.UpdateCoinValueString(coinValue);
        uiStrings.UpdateCoinsString(coins);
        uiStrings.UpdateBetString(totalBet);
        uiStrings.UpdateBalanceString(bankroll);
    }

    // Decrease bankroll and coins when base spin is played and player has bankroll left to make bet.
    public bool MakeBet()
    {
        if (coins - (totalBet / coinValue) >= 0)
        {
            coins -= (totalBet / coinValue);
            bankroll -= totalBet;
            uiStrings.UpdateCoinsString(coins);
            uiStrings.UpdateBalanceString(bankroll);
            return true;
        }
        else
        {
            return false;
        }
    }

    // After base spin or freespins are finished payout win to bankroll and coins.
    public void GetTotalWin()
    {
        coins += TotalWin;
        bankroll += TotalWin * coinValue;
        uiStrings.UpdateCoinsString(coins);
        uiStrings.UpdateBalanceString(bankroll);
    }

    // Reset win counters.
    public void ClearWins()
    {
        spinWin = 0;
        TotalWin = 0;
    }

    // Check and payout all the win lines.
    public void GetLineWins(SpinData spinData)
    {
        // Normal reel wins.
        foreach (LineHit hit in spinData.LineHits)
        {
            spinWin += hit.WinMultiplier * CoinsPerLine;
        }

        // Expanding symbol win.
        if (spinData.ExpandingSymbolHit)
        {
            spinWin += spinData.ExpandingSymbolMultiplier * CoinsPerLine * NOfLines;
        }

        // Book symbol win.
        if (spinData.BookWinMultiplier > 0)
        {
            spinWin += spinData.BookWinMultiplier * coinValue;
        }

        // Add all wins to total win.
        TotalWin += spinWin;

        // Show total win to player.
        if (TotalWin > 0)
        {
            uiStrings.UpdateTotalWinString(TotalWin);
        }

        // Reset this spin win.
        spinWin = 0;
    }

    // Add coin value button.
    public void AddCoinValue()
    {
        if (coinValue < 1 && !gameManager.FreespinsActivated && gameManager.spinCompleted)
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

            // Update UI.
            coins = bankroll / coinValue;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsString(coins);
            uiStrings.UpdateCoinValueString(coinValue);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    // Remove from coin value button.
    public void RemoveCoinValue()
    {
        if (coinValue > 0.01M && !gameManager.FreespinsActivated && gameManager.spinCompleted)
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

            // Update UI.
            coins = bankroll / coinValue;
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsString(coins);
            uiStrings.UpdateCoinValueString(coinValue);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    // Add coin value per line button.
    public void AddCoinPerLine()
    {
        if (CoinsPerLine < 5 && !gameManager.FreespinsActivated && gameManager.spinCompleted)
        {
            CoinsPerLine++;

            // Update UI.
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsPerLineString(CoinsPerLine);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    // Remove coin value per line button.
    public void RemoveCoinPerLine()
    {
        if (CoinsPerLine > 1 && !gameManager.FreespinsActivated && gameManager.spinCompleted)
        {
            CoinsPerLine--;

            // Update UI.
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateCoinsPerLineString(CoinsPerLine);
            uiStrings.UpdateBetString(totalBet);
        }
    }

    // Add line button.
    public void AddLine()
    {
        if (NOfLines < 10 && !gameManager.FreespinsActivated && gameManager.spinCompleted)
        {
            NOfLines++;

            // Update UI.
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateBetString(totalBet);
            uiStrings.UpdateLineString(NOfLines);
        }
    }

    // Remove line button.
    public void RemoveLine()
    {
        if (NOfLines > 1 && !gameManager.FreespinsActivated && gameManager.spinCompleted)
        {
            NOfLines--;

            // Update UI.
            totalBet = coinValue * CoinsPerLine * NOfLines;
            uiStrings.UpdateBetString(totalBet);
            uiStrings.UpdateLineString(NOfLines);
        }
    }
}
