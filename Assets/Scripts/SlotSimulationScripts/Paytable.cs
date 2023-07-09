/// <summary>
/// Book of Paide paytable.
/// Returns bet multiplier according to win id and win symbol.
/// </summary>
public class Paytable
{
    public static int GetWinMultiplier(int winId, Symbol winSymbol)
    {
        int multiplier = 0;

        switch (winSymbol)
        {
            case Symbol.Ten:
            case Symbol.Jack:
            case Symbol.Queen:
                if (winId == 3) { multiplier = 5; }
                else if (winId == 4) {  multiplier = 25; }
                else if (winId == 5) { multiplier = 100; }

                return multiplier;
            case Symbol.King:
            case Symbol.Ace:
                if (winId == 3) { multiplier = 5; }
                else if (winId == 4) { multiplier = 40; }
                else if (winId == 5) { multiplier = 150; }

                return multiplier;
            case Symbol.Seire:
            case Symbol.Pafka:
                if (winId == 2) { multiplier = 5; }
                else if (winId == 3) { multiplier = 30; }
                else if (winId == 4) { multiplier = 100; }
                else if (winId == 5) { multiplier = 750; }

                return multiplier;
            case Symbol.Mihu:
                if (winId == 2) { multiplier = 5; }
                else if (winId == 3) { multiplier = 40; }
                else if (winId == 4) { multiplier = 400; }
                else if (winId == 5) { multiplier = 2000; }

                return multiplier;
            case Symbol.Rolts:
                if (winId == 2) { multiplier = 10; }
                else if (winId == 3) { multiplier = 100; }
                else if (winId == 4) { multiplier = 1000; }
                else if (winId == 5) { multiplier = 5000; }

                return multiplier;
            case Symbol.Book:
                if (winId == 3) { multiplier = 2; }
                else if (winId == 4) { multiplier = 20; }
                else if (winId == 5) { multiplier = 200; }

                return multiplier;
            default: return 0;
        }
    }
}
