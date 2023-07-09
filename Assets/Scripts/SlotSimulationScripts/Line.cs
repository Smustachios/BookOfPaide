/// <summary>
/// Class used to check lines for line wins.
/// </summary>
public class Line
{
    public Symbol[] LineSymbols { get; private set; }


    public Line()
    {
        LineSymbols = new Symbol[5];
    }

    // Checks line for a win, by comparing if symbols match. Returns line hit data object.
    public LineHit CheckLineForWin(int lineId)
    {
        // Make new line hit with win symbol and assigned line id. Win symbol will be first symbol thats not a book.
        // If all symbols on line are books win symbol will be Rolts.
        LineHit lineHit = new()
        {
            WinSymbol = GetWinSymbol(),
            LineId = lineId
        };

        ConvertBooks(lineHit.WinSymbol); // Change all the books on the line to win symbols.

        // 5 same symbols.
        if (IsSymbolsSame(LineSymbols[0], LineSymbols[1], LineSymbols[2], LineSymbols[3], LineSymbols[4]))
        {
            lineHit.WinId = 5;
            lineHit.DidLineHit = true;
        }

        // 4 same symbols.
        else if (IsSymbolsSame(LineSymbols[0], LineSymbols[1], LineSymbols[2], LineSymbols[3]) && !IsSymbolsSame(LineSymbols[4], lineHit.WinSymbol))
        {
            lineHit.WinId = 4;
            lineHit.DidLineHit = true;
        }

        // 3 same symbols.
        else if (IsSymbolsSame(LineSymbols[0], LineSymbols[1], LineSymbols[2]) && !IsSymbolsSame(LineSymbols[3], lineHit.WinSymbol))
        {
            lineHit.WinId = 3;
            lineHit.DidLineHit = true;
        }

        // 2 same symbols. 2 symbols will only hit if win symbol is premium symbol.
        else if (IsSymbolsSame(LineSymbols[0], LineSymbols[1]) && IsPremiumSymbol(lineHit.WinSymbol) && !IsSymbolsSame(LineSymbols[2], lineHit.WinSymbol))
        {
            lineHit.WinId = 2;
            lineHit.DidLineHit = true;
        }

        // Nothing hit
        else
        {
            lineHit.WinId = 0;
            lineHit.DidLineHit = false;
        }

        return lineHit;
    }

    // Also used to check if expanding symbol is premium while in bonus game.
    public static bool IsPremiumSymbol(Symbol symbol)
    {
        if (symbol == Symbol.Mihu ||
            symbol == Symbol.Pafka ||
            symbol == Symbol.Seire ||
            symbol == Symbol.Rolts
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Convert all books on the line to win symbols. It will simplify line checking alot.
    private void ConvertBooks(Symbol winSymbol)
    {
        for (int c = 0; c < LineSymbols.Length; c++)
        {
            if (LineSymbols[c] == Symbol.Book)
            {
                LineSymbols[c] = winSymbol;
            }
        }
    }

    // First symbol thats not a book will be win symbol. If all symbols are books, win symbol will be Rolts.
    private Symbol GetWinSymbol()
    {
        for (int c = 0; c < LineSymbols.Length; c++)
        {
            if (LineSymbols[c] != Symbol.Book)
            {
                return LineSymbols[c];
            }
        }

        return Symbol.Rolts;
    }

    // Returns wheater all symbols are same.
    private bool IsSymbolsSame(params Symbol[] symbols)
    {
        Symbol prevSymbol;
        Symbol nextSymbol;

        for (int c = 0; c < symbols.Length - 1; c++)
        {
            prevSymbol = symbols[c];
            nextSymbol = symbols[c + 1];

            if (prevSymbol == nextSymbol)
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
