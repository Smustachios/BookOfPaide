using System.Threading;
using TMPro;
using UnityEngine;


/// <summary>
/// All the ui text elements and update methods.
/// </summary>
public class UIStrings : MonoBehaviour
{
    public TextMeshProUGUI linesString;
    public TextMeshProUGUI betString;
    public TextMeshProUGUI coinValueString;
    public TextMeshProUGUI coinsPerLineString;
    public TextMeshProUGUI coinsString;
    public TextMeshProUGUI totalWinString;
    public TextMeshProUGUI freespinsLeftString;
    public TextMeshProUGUI congratsString;
    public TextMeshProUGUI balanceString;
    public TextMeshProUGUI autospinsText;


    // Shows how many lines player using.
    public void UpdateLineString(int nOfLines)
    {
        linesString.text = $"LINES\n{nOfLines}";
    }

    // Shows total bet in money value.
    public void UpdateBetString(decimal bet)
    {
        betString.text = $"BET: {System.Math.Round(bet, 2)}";
    }

    // Shows coin value.
    public void UpdateCoinValueString(decimal coinValue)
    {
        coinValueString.text = $"COIN VALUE\n{System.Math.Round(coinValue, 2)}";
    }

    // Shows how many coins player bets per line.
    public void UpdateCoinsPerLineString(decimal coinsPerLine)
    {
        coinsPerLineString.text = $"COINS\n{System.Math.Round(coinsPerLine, 0)}";
    }

    // Shows how many coins player has.
    public void UpdateCoinsString(decimal coins)
    {
        coinsString.text = $"COINS: {System.Math.Round(coins, 0)}";
    }

    // Shows total win player has at the moment.
    public void UpdateTotalWinString(decimal spinWin)
    {
        totalWinString.text = $"WIN: {System.Math.Round(spinWin, 0)} COINS!";
    }

    // Shows before each base spin.
    public void GoodLuckText()
    {
        totalWinString.text = "Good Luck!";
    }

    // Shows how many freespins player has left.
    public void UpdateFreespinsLeft(int freespinsLeft, int totalFreespins)
    {
        freespinsLeftString.text = $"Free spin {freespinsLeft} of {totalFreespins}";
    }

    // Shows congrats text
    public void UpdateCongratsString(decimal totalWin, int freespinsPlayed)
    {
        congratsString.text = $"CONGRATULATION!!\nYOU WIN {System.Math.Round(totalWin, 0)} COINS\nWITH {freespinsPlayed} FREESPINS";
    }

    // Update balance text
    public void UpdateBalanceString(decimal balance)
    {
        balanceString.text = $"BALANCE: {System.Math.Round(balance, 2)}";
    }

    // Update number of autospins
    public void UpdateAutospinsString(string message)
    {
        autospinsText.text = message;
    }
}
