public class Line
{
    public Symbol[] LineSymbols { get; private set; }


    public Line()
    {
        LineSymbols = new Symbol[5];
    }

    public LineHit CheckLineForWin(int lineId)
    {
        LineHit lineHit = new()
        {
            WinSymbol = GetWinSymbol(),
            LineId = lineId
        };

        ConvertBooks(lineHit.WinSymbol);

        if (IsSymbolsSame(LineSymbols[0], LineSymbols[1], LineSymbols[2], LineSymbols[3], LineSymbols[4]) || lineHit.WinSymbol == Symbol.Book)
        {
            lineHit.WinId = 5;
            lineHit.DidLineHit = true;
        }

        else if (IsSymbolsSame(LineSymbols[0], LineSymbols[1], LineSymbols[2], LineSymbols[3]) && !IsSymbolsSame(LineSymbols[4], lineHit.WinSymbol))
        {
            lineHit.WinId = 4;
            lineHit.DidLineHit = true;
        }
        else if (IsSymbolsSame(LineSymbols[0], LineSymbols[1], LineSymbols[2]) && !IsSymbolsSame(LineSymbols[3], lineHit.WinSymbol))
        {
            lineHit.WinId = 3;
            lineHit.DidLineHit = true;
        }
        else if (IsSymbolsSame(LineSymbols[0], LineSymbols[1]) && IsPremiumSymbol(lineHit.WinSymbol) && !IsSymbolsSame(LineSymbols[2], lineHit.WinSymbol))
        {
            lineHit.WinId = 2;
            lineHit.DidLineHit = true;
        }
        else
        {
            lineHit.WinId = 0;
            lineHit.DidLineHit = false;
        }

        return lineHit;
    }

    private void ConvertBooks(Symbol winSymbol)
    {
        if (winSymbol != Symbol.Book)
        {
            for (int c = 0; c < LineSymbols.Length; c++)
            {
                if (LineSymbols[c] == Symbol.Book)
                {
                    LineSymbols[c] = winSymbol;
                }
            }
        }
    }

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

    private Symbol GetWinSymbol()
    {
        for (int c = 0; c < LineSymbols.Length; c++)
        {
            if (LineSymbols[c] != Symbol.Book)
            {
                return LineSymbols[c];
            }
        }

        return Symbol.Book;
    }

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
