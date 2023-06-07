public class BonusGame : BaseGame
{
    public SpinData Spin(int nOfLines, Symbol expandingSymbol)
    {
        SpinData spinData = new();
        Board board = SetRandomBoard(reels.BonusReels);
        lines = new Lines(nOfLines);

        spinData.LineHits = CheckLines(board);
        spinData.boardStrings = PrintBoard(board);
        spinData.RandomReelSpots = board.RandomReelSpots;
        spinData.BonusGameWon = BonusGameWon(board);
        spinData.ExpandingSymbolWinID = CheckExpandingWin(expandingSymbol, board);
        spinData.ExpandingSymbolHit = spinData.ExpandingSymbolWinID >= 2;

        if (spinData.ExpandingSymbolHit)
        {
            spinData.ExpandingSymbolMultiplier = Paytable.GetWinMultiplier(spinData.ExpandingSymbolWinID, expandingSymbol);
        }

        return spinData;
    }

    private int CheckExpandingWin(Symbol expandingSymbol, Board board)
    {
        int expandingSymbolCount = CountSymbols(expandingSymbol, board);

        return expandingSymbolCount switch
        {
            2 when Line.IsPremiumSymbol(expandingSymbol) => 2,
            3 => 3,
            4 => 4,
            5 => 5,
            _ => 0
        };
    }

    private int CountSymbols(Symbol expandingSymbol, Board board)
    {
        int symbolCounter = 0;

        foreach (Symbol[] line in board.GameBoard)
        {
            foreach (Symbol symbol in line)
            {
                if (symbol == expandingSymbol)
                {
                    symbolCounter++;
                }
            }
        }

        return symbolCounter;
    }
}
