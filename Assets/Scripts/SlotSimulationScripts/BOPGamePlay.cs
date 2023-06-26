/// <summary>
/// Spins and returns spin data for the game. Needs to know if it needs to spin base or bonus game.
/// </summary>
public class BOPGamePlay
{
    private BaseGame baseGame = new();
    private BonusGame bonusGame = new();


    // Spin the game. If freespins are activated needs to be provided expanding symbol aswell.
    public SpinData Spin(bool freespinsActive, int nOfLines, Symbol expandingSymbol = Symbol.Book)
    {
        SpinData spinData;

        if (!freespinsActive)
        {
            spinData = CompleteSpin(nOfLines);

            if (spinData.BonusGameWon)
            {
                ActivateFreespins(spinData);
            }
        }

        else
        {
            spinData = CompleteFreeSpin(expandingSymbol, nOfLines);
        }

        return spinData;
    }

    private SpinData CompleteSpin(int nOfLines)
    {
        SpinData spinData = baseGame.Spin(nOfLines);

        return spinData;
    }

    private SpinData CompleteFreeSpin(Symbol expandingSymbol, int nOfLines)
    {
        SpinData spinData = bonusGame.Spin(nOfLines, expandingSymbol);

        return spinData;
    }

    // If base game activates freespins make a expanding symbol and return to external caller for to be feed back later.
    private void ActivateFreespins(SpinData data)
    {
        data.ExpandingSymbol = Reels.GetRandomExpandingSymbol(out int randomExpandingReelSpot);
        data.RandomExpaningReelSpot = randomExpandingReelSpot;
    }
}
