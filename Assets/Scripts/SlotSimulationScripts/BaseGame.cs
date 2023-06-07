using System.Collections.Generic;

public class BaseGame
{
    public Board Board { get; set; }

    protected Reels reels = new();
    protected Lines lines;
    

    public SpinData Spin(int nOfLines)
    {
        SpinData spinData = new();
        Board board = SetRandomBoard(reels.GameReels);
        lines = new Lines(nOfLines);

        spinData.LineHits = CheckLines(board);
        spinData.boardStrings = PrintBoard(board);
        spinData.RandomReelSpots = board.RandomReelSpots;
        spinData.BonusGameWon = BonusGameWon(board);

        return spinData;
    }

    protected bool BonusGameWon(Board board)
    {
        int bookCounter = 0;

        foreach (Symbol[] symbols in board.GameBoard)
        {
            foreach (Symbol symbol in symbols)
            {
                if (symbol == Symbol.Book)
                {
                    bookCounter++;
                }
            }
        }

        if (bookCounter >= 3)
        {
            return true;
        }

        return false;
    }

    protected Board SetRandomBoard(Reel[] gameReels)
    {
        Board board = new(5, 3);

        for (int c = 0; c < gameReels.Length; c++)
        {
            board.GameBoard[c] = reels.GetRandomReelSymbols(gameReels[c], out int randomReelSpot);
            board.RandomReelSpots[c] = randomReelSpot;
        }

        Board = board;
        return board;
    }

    protected List<LineHit> CheckLines(Board board)
    {
        LineHit[] lineHits = new LineHit[lines.GameLines.Count];
        List<LineHit> wonLines = new List<LineHit>();

        int lineCounter = 1;

        foreach (int[] line in lines.GameLines)
        {
            LineHit lineHit = new ();
            Line lineCheck = new ();

            for (int c = 0; c < board.GameBoard.Length; c++)
            {
                Symbol symbol = board.GameBoard[c][line[c]];
                lineCheck.LineSymbols[c] = symbol;
            }

            lineHit = lineCheck.CheckLineForWin(lineCounter);
            lineHits[lineCounter - 1] = lineHit;
            lineCounter++;
        }

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

    protected string[] PrintBoard(Board board)
    {
        string[] boardLines = new string[3];

        for (int i = 0; i < 3; i++)
        {
            string debug = "";

            foreach (Symbol[] line in board.GameBoard)
            {
                debug += line[i];
            }

            boardLines[i] = debug;
        }

        return boardLines;
    }
}
