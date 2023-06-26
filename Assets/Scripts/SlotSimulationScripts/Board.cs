/// <summary>
/// Board of the game. Holds symbols on as arrays once they are put on the board randomly.
/// Also holds values of the last spins reel random spots, from where the symbols were taken.
/// </summary>
public class Board
{
    public Symbol[][] GameBoard { get; private set; }
    public int[] RandomReelSpots {  get; private set; }


    public Board(int columns, int columnHeight)
    {
        GameBoard = new Symbol[columns][];
        RandomReelSpots = new int[5];

        for (int i = 0; i < columns; i++)
        {
            GameBoard[i] = new Symbol[columnHeight];
        }
    }
}
