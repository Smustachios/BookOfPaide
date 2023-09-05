using System.Collections.Generic;


/// <summary>
/// Spin information after virtual spin. Used to show player visually what happened.
/// Freespin and base spin will return different variants of this class.
/// </summary>
public class SpinData
{
    // This data will be filled regardless what spin was made.
    public int[] RandomReelSpots { get; internal set; } // All 5 random spots on the virtual reels that given spin got.
    public List<LineHit> LineHits { get; internal set; } // All line hit data. Only has data from lines that actually hitted something.
    public bool BonusGameWon { get; internal set; } = false;
    public int BookWinMultiplier { get; internal set; }
    public bool IsTease { get; internal set; } = false;
    public int StartTeaseReel { get; internal set; } = -1;

    // This data will only be filled if spin was freespin.
    public Symbol ExpandingSymbol { get; internal set; }
    public bool ExpandingSymbolHit { get; internal set; }
    public int ExpandingSymbolMultiplier { get; internal set; } // Will only be filled if expanding symbol actually hit.
    public int RandomExpaningReelSpot { get; internal set; } // Only filled once, when freespins are activated.
    public List<int> ExpandingSymbolRowID { get; internal set; } // On what reels expanding symbols hit.
}
