using System.Collections.Generic;

public class SpinData
{
    public int[] RandomReelSpots { get; set; }
    public List<LineHit> LineHits { get; set; }
    public bool BonusGameWon { get; set; } = false;
    public bool ExpandingSymbolHit { get; internal set; }
    public int ExpandingSymbolMultiplier { get; set; }
    public Symbol ExpandingSymbol { get; set; }
    public int RandomExpaningReelSpot { get; set; }
    public int BookWinMultiplier { get; set; }
    public List<int> ExpandingSymbolRowID { get; internal set; }
}
