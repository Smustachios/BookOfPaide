using System.Collections.Generic;
using System.Runtime.ExceptionServices;

public class Lines
{
    public List<int[]> GameLines { get; private set; } = new List<int[]>();

    private int[] lineOne = new int[] { 1, 1, 1, 1, 1 };
    private int[] lineTwo = new int[] { 0, 0, 0, 0, 0, };
    private int[] lineThree = new int[] { 2, 2, 2, 2, 2 };
    private int[][] allLines;


    public Lines(int nOfLines) 
    {
        allLines = new int[][] { lineOne, lineTwo, lineThree };

        for (int c = 0; c < nOfLines; c++)
        {
            GameLines.Add(allLines[c]);
        }
    }
}
