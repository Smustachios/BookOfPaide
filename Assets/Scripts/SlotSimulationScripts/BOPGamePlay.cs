public class BOPGamePlay
{
    private BaseGame baseGame = new();
    private BonusGame bonusGame = new();


    public SpinData Spin(bool freespinsActive, decimal lineBet, int nOfLines, Symbol expandingSymbol = Symbol.Book)
    {
        SpinData spinData;

        if (!freespinsActive)
        {
            spinData = CompleteSpin(lineBet, nOfLines);

            if (spinData.BonusGameWon)
            {
                ActivateFreespins(spinData);
            }
        }

        else
        {
            spinData = CompleteFreeSpin(expandingSymbol, lineBet, nOfLines);
        }

        return spinData;
    }

    private SpinData CompleteSpin(decimal lineBet, int nOfLines)
    {
        SpinData spinData = baseGame.Spin(nOfLines);

        foreach (LineHit hit in spinData.LineHits)
        {
            spinData.SpinWin += lineBet * hit.WinMultiplier;
        }

        return spinData;
    }

    private SpinData CompleteFreeSpin(Symbol expandingSymbol, decimal lineBet, int nOfLines)
    {
        SpinData spinData = bonusGame.Spin(nOfLines, expandingSymbol);

        foreach (LineHit hit in spinData.LineHits)
        {
            spinData.SpinWin += lineBet * hit.WinMultiplier;
        }

        if (spinData.ExpandingSymbolWinID != 0)
        {
            spinData.SpinWin += spinData.ExpandingSymbolMultiplier * lineBet * nOfLines;
        }

        return spinData;
    }

    private void ActivateFreespins(SpinData data)
    {
        data.ExpandingSymbol = Reels.GetRandomExpandingSymbol(out int randomExpandingReelSpot);
        data.RandomExpaningReelSpot = randomExpandingReelSpot;
    }
}
