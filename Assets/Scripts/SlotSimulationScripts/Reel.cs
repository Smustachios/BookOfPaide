/// <summary>
/// Can be any reel used in a slot game. Takes in symbols in constructor and makes reel accordingly.
/// </summary>
public class Reel
{
    public Symbol[] ReelSymbols { get; private set; }

    public Reel(params Symbol[] symbols)
    {
        ReelSymbols = new Symbol[symbols.Length];
        ReelSymbols = symbols;
    }
}
