using System.Collections.Generic;

public class SpinData
{
    public bool BonusGameWon { get; set; } = false;
    public int[] RandomReelSpots { get; set; }
    public List<LineHit> LineHits { get; set; }
    public int expandingSymbolWinID { get; set; }
}
