using System.Collections.Generic;


/// <summary>
/// Makes bonus spin and return all spin data. This variant will return both
/// normal spin data and bonus data aswell.
/// </summary>
public class BonusGame : BaseGame
{
    private readonly List<int> expandingSymbolLineId = new List<int>(); // Hold row id where expanding symbol is.


    public SpinData Spin(int nOfLines, Symbol expandingSymbol)
    {
        SpinData spinData = new();
        Board board = SetRandomBoard(reels.BonusReels);

        spinData.LineHits = CheckLines(board, nOfLines);
        spinData.RandomReelSpots = board.RandomReelSpots;
        spinData.BonusGameWon = BonusGameWon(board, out int bookWin); // Bonus can be retriggered with active bonus.
        spinData.BookWinMultiplier = bookWin;

        // Set expanding symbol wins data
        int expandingWinID = CheckExpandingWin(expandingSymbol, board);
        spinData.ExpandingSymbolHit = expandingWinID >= 2;
        spinData.ExpandingSymbolRowID = expandingSymbolLineId;

        if (spinData.ExpandingSymbolHit)
        {
            spinData.ExpandingSymbolMultiplier = Paytable.GetWinMultiplier(expandingWinID, expandingSymbol);
        }

        return spinData;
    }

    // Return expanding symbol win id
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

    // Count expanding symbols. If its on the row of the board set that row to be
    // used later for animations.
    private int CountSymbols(Symbol expandingSymbol, Board board)
    {
        int symbolCounter = 0;

        for (int c = 0; c < board.GameBoard.Length; c++)
        {
            Symbol[] line = board.GameBoard[c];

            foreach (Symbol symbol in line)
            {
                if (symbol == expandingSymbol)
                {
                    symbolCounter++;
                    expandingSymbolLineId.Add(c);
                }
            }
        }

        return symbolCounter;
    }
}
