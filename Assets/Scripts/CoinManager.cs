using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public decimal Bankroll = 1000.0M;
    public decimal BetPerLine { get; set; } = 1.0M;
    public decimal TotalWin { get; set; }
    public decimal SpinWin { get; set; }

    private decimal totalBet;


    public bool MakeBet(int nOfLines)
    {
        totalBet = nOfLines * BetPerLine;

        if (Bankroll - totalBet >= 0)
        {
            Bankroll -= totalBet;
            Debug.Log(Bankroll);
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
        return multiplier * BetPerLine;
    }

    public void GetTotalWin()
    {
        Bankroll += TotalWin;
    }

    public void ClearWins()
    {
        SpinWin = 0;
        TotalWin = 0;
    }

    public void GetLineWins(SpinData spinData, int nOfLines)
    {
        foreach (LineHit hit in spinData.LineHits)
        {
            SpinWin += GetLineWin(hit.WinMultiplier);
        }

        if (spinData.ExpandingSymbolHit)
        {
            SpinWin += GetLineWin(spinData.ExpandingSymbolMultiplier) * nOfLines;
        }

        TotalWin += SpinWin;
        SpinWin = 0;
    }
}
