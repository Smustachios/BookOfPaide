using System.Collections.Generic;

public class Lines
{
    public List<int[]> GameLines { get; private set; } = new List<int[]>();

    private int[] lineOne = new int[] { 1, 1, 1, 1, 1 };
    private int[] lineTwo = new int[] { 0, 0, 0, 0, 0, };
    private int[] lineThree = new int[] { 2, 2, 2, 2, 2 };
    private int[] lineFour = new int[] { 0, 1, 2, 1, 0 };
    private int[] lineFive = new int[] { 2, 1, 0, 1, 2 };
    private int[] lineSix = new int[] { 1, 0, 0, 0, 1 };
    private int[] lineSeven = new int[] { 1, 2, 2, 2, 1 };
    private int[] lineEight = new int[] { 0, 0, 1, 2, 2 };
    private int[] lineNine = new int[] { 2, 2, 1, 0, 0 };
    private int[] lineTen = new int[] { 1, 2, 1, 0, 1 };

    private int[][] allLines;


    public Lines(int nOfLines) 
    {
        allLines = new int[][] { lineOne, lineTwo, lineThree, lineFour, lineFive, lineSix, lineSeven, lineEight, lineNine, lineTen };

        for (int c = 0; c < nOfLines; c++)
        {
            GameLines.Add(allLines[c]);
        }
    }
}
