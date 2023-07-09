using System.Collections.Generic;


/// <summary>
/// Ten lines for Book of Paide. Makes all lines on construction
/// and returns only lines needed for spin with GetGameLines method.
/// </summary>
public class Lines
{
    private readonly int[] lineOne = new int[] { 1, 1, 1, 1, 1 };
    private readonly int[] lineTwo = new int[] { 0, 0, 0, 0, 0, };
    private readonly int[] lineThree = new int[] { 2, 2, 2, 2, 2 };
    private readonly int[] lineFour = new int[] { 0, 1, 2, 1, 0 };
    private readonly int[] lineFive = new int[] { 2, 1, 0, 1, 2 };
    private readonly int[] lineSix = new int[] { 1, 0, 0, 0, 1 };
    private readonly int[] lineSeven = new int[] { 1, 2, 2, 2, 1 };
    private readonly int[] lineEight = new int[] { 0, 0, 1, 2, 2 };
    private readonly int[] lineNine = new int[] { 2, 2, 1, 0, 0 };
    private readonly int[] lineTen = new int[] { 1, 2, 1, 0, 1 };

    private readonly int[][] allLines;


    public Lines() 
    {
        allLines = new int[][] { lineOne, lineTwo, lineThree, lineFour, lineFive, lineSix, lineSeven, lineEight, lineNine, lineTen };
    }

    public List<int[]> GetGameLines(int nOfLines)
    {
        List<int[]> gameLines = new ();

        for (int c = 0; c < nOfLines; c++)
        {
            gameLines.Add(allLines[c]);
        }

        return gameLines;
    }
}
