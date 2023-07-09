/// <summary>
/// Line hit data class.
/// </summary>
public class LineHit
{
    public Symbol WinSymbol { get; internal set; }
    public int WinId { get; internal set; } // Represents how many symbol match in the line.
    public int LineId { get; internal set; }
    public bool DidLineHit { get; internal set; }
    public int WinMultiplier { get; internal set; } // Represents multiplier this line win returns to be multiplied by the bet.
}
