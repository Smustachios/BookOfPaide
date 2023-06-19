using System.Collections.Generic;

public class SpinData
{
    public int[] RandomReelSpots { get; set; }
    public List<LineHit> LineHits { get; set; }
    public bool BonusGameWon { get; set; } = false;
    public int ExpandingSymbolWinID { get; set; }
    public bool ExpandingSymbolHit { get; internal set; }
    public int ExpandingSymbolMultiplier { get; set; }
    public Symbol ExpandingSymbol { get; set; }
    public int RandomExpaningReelSpot { get; set; }
    public decimal SpinWin { get; set; }
    public int BookWinMultiplier { get; set; }

    public override string ToString()
    {
        return $"Spinwin: {SpinWin}. Freespins won {BonusGameWon}.";
    }
}
