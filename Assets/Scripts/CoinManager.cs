using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public decimal Bankroll { get; private set; }

    private decimal betPerLine;
    private decimal totalBet;


    public bool MakeBet(int nOfLines, decimal betPerLine)
    {
        this.betPerLine = betPerLine;
        totalBet = nOfLines * betPerLine;

        if (Bankroll - totalBet >= 0)
        {
            Bankroll -= totalBet;
            return true;
        }
        else
        {
            totalBet = 0;
            return false;
        }
    }

    public void SetBankRoll(decimal bankRoll)
    {
        Bankroll = bankRoll;
    }

    public decimal GetLineWin(int multiplier)
    {
        return multiplier * betPerLine;
    }

    public void GetTotalWin(decimal totalWin)
    {
        Bankroll += totalWin;
    }
}
