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
