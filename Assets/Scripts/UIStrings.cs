using TMPro;
using UnityEngine;

public class UIStrings : MonoBehaviour
{
    public TextMeshProUGUI linesString;
    public TextMeshProUGUI betString;
    public TextMeshProUGUI coinValueString;
    public TextMeshProUGUI coinsPerLineString;
    public TextMeshProUGUI coinsString;
    public TextMeshProUGUI spinWinString;


    public void UpdateLineString(int nOfLines)
    {
        linesString.text = $"LINES\n{nOfLines}";
    }

    public void UpdateBetString(decimal bet)
    {
        betString.text = $"BET: {System.Math.Round(bet, 2)}";
    }

    public void UpdateCoinValueString(decimal coinValue)
    {
        coinValueString.text = $"COIN VALUE\n{System.Math.Round(coinValue, 2)}";
    }

    public void UpdateCoinsPerLineString(decimal coinsPerLine)
    {
        coinsPerLineString.text = $"COINS\n{System.Math.Round(coinsPerLine, 0)}";
    }

    public void UpdateCoinsString(decimal coins)
    {
        coinsString.text = $"COINS: {System.Math.Round(coins, 0)}";
    }

    public void UpdateSpinWinString(decimal spinWin)
    {
        spinWinString.text = $"WIN: {System.Math.Round(spinWin, 0)} COINS!";
    }

    public void GoodLuckText()
    {
        spinWinString.text = "Good Luck!";
    }
}
