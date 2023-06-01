public class Reel
{
    public Symbol[] ReelSymbols { get; private set; }

    public Reel(params Symbol[] symbols)
    {
        ReelSymbols = new Symbol[symbols.Length];
        ReelSymbols = symbols;
    }
}
