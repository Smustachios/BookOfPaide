using System.Collections.Generic;


/// <summary>
/// Spins base spin of the game. Returns base spin variant of the spin data.
/// </summary>
public class BaseGame
{
    protected Reels reels = new();
    protected Lines lines = new();
    protected bool isTease = false;
    protected int startTeaseReel = -1;
    

    // Make and return base spin data
    public SpinData Spin(int nOfLines)
    {
        SpinData spinData = new();
        Board board = SetRandomBoard(reels.GameReels);

        spinData.LineHits = CheckLines(board, nOfLines);
        spinData.RandomReelSpots = board.RandomReelSpots;
        spinData.BonusGameWon = BonusGameWon(board, out int bookWin);
        spinData.IsTease = isTease;
        spinData.StartTeaseReel = startTeaseReel;
        spinData.BookWinMultiplier = bookWin;

        return spinData;
    }

    // Return true if there is 3 or more books on random board.
    // Pass out multiplier of book win.
    protected bool BonusGameWon(Board board, out int bookMultiplier)
    {
        int bookCounter = GetBookCount(board);

        if (bookCounter >= 3)
        {
            bookMultiplier = GetBookMultiplier(bookCounter);
            return true;
        }

        bookMultiplier = 0;
        return false;
    }

    // Get random spots from the reels and use 3 symbols from that spot to make up
    // randomly made board. Save symbols and spots used for gettin symbols to board then return it.
    protected Board SetRandomBoard(Reel[] gameReels)
    {
        Board board = new(5, 3);

        for (int c = 0; c < gameReels.Length; c++)
        {
            board.GameBoard[c] = reels.GetRandomReelSymbols(gameReels[c], out int randomReelSpot);
            board.RandomReelSpots[c] = randomReelSpot;
        }

        return board;
    }

    // Check each line against randomly made board to find if line hit or not.
    // Save all the lines that did hit and return them.
    protected List<LineHit> CheckLines(Board board, int nOfLines)
    {
        LineHit[] lineHits = new LineHit[lines.GetGameLines(nOfLines).Count]; // All line hits. Whether its a hit or not.
        List<LineHit> wonLines = new List<LineHit>(); // Only lines that hits.
        Line lineCheck = new(); // Use to check symbol matches.

        int lineCounter = 1; // Line ids starts with 1.

        // Check all the lines that should be used for this spin.
        foreach (int[] line in lines.GetGameLines(nOfLines))
        {
            LineHit lineHit = new ();

            // Get all the symbols from the board at the line spots.
            for (int c = 0; c < board.GameBoard.Length; c++)
            {
                Symbol symbol = board.GameBoard[c][line[c]];
                lineCheck.LineSymbols[c] = symbol;
            }

            lineHit = lineCheck.CheckLineForWin(lineCounter); // Check line for win.
            lineHits[lineCounter - 1] = lineHit;
            lineCounter++;
        }

        // Return only lines that actually hit something.
        foreach (LineHit lineHit in lineHits)
        {
            if (lineHit.DidLineHit == true)
            {
                lineHit.WinMultiplier = Paytable.GetWinMultiplier(lineHit.WinId, lineHit.WinSymbol);
                wonLines.Add(lineHit);
            }
        }

        return wonLines;
    }

    // Count and return book count.
    private int GetBookCount(Board board)
    {
        int bookCounter = 0;
        isTease = false;
        startTeaseReel = -1;

        for (int i = 0; i < board.GameBoard.Length; i++)
        {
            foreach (Symbol symbol in board.GameBoard[i])
            {
                if (symbol == Symbol.Book)
                {
                    bookCounter++;

                    CheckTease(bookCounter, i);
                }
            }
        }

        return bookCounter;
    }

    // Gets called only when there will be 3 or more books.
    // Returns book multiplier.
    private int GetBookMultiplier(int bookCount)
    {
        if (bookCount == 3) return 2;
        else if (bookCount == 4) return 20;
        else { return 200; }
    }
    
    // Check if spin is tease spin.
    private void CheckTease(int bookCount, int reelId)
    {
        if (bookCount == 2 && reelId != 4)
        {
            isTease = true;
            startTeaseReel = reelId + 2;
        }
    }
}
