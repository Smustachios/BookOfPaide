using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nOfLines = 3;
    public int nOfFreespins = 10;
    public decimal betPerLine = 1.0M;

    private BaseGame baseGame;
    private CoinManager coinManager;

    private bool bonusGame = false;
    private decimal spinWin = 0.0M;
    private decimal totalWin = 0.0M;
    private int freespinsLeft = 0;


    private void Start()
    {
        StartGame();    
    }

    public void StartGame()
    {
        coinManager = new();
        baseGame = new();
        

        while (!bonusGame)
        {
            SpinData spinData = CompleteSpin();
            PrintBoard(baseGame);

            Debug.Log($"Spin win {spinWin}, bonus win: {spinData.BonusGameWon}");

            bonusGame = spinData.BonusGameWon;

            if (bonusGame)
            {
                freespinsLeft = nOfFreespins;
            }

            totalWin += spinWin;
            spinWin = 0;
        }
        while (bonusGame)
        {

        }

        Debug.Log($"Total win: {totalWin}, bankroll left: {coinManager.Bankroll}");
    }

    private SpinData CompleteSpin()
    {
        coinManager.MakeBet(nOfLines, betPerLine);

        SpinData spinData = baseGame.Spin(nOfLines);

        foreach (LineHit hit in spinData.LineHits)
        {
            spinWin += coinManager.GetLineWin(hit.WinMultiplier);
        }

        coinManager.GetTotalWin(spinWin);

        return spinData;
    }

    private SpinData CompleteFreeSpin()
    {
        SpinData spinData = baseGame.Spin(nOfLines);

        return spinData;
    }

    private void PrintBoard(BaseGame game)
    {
        for (int i = 0; i < 3; i++)
        {
            string debug = "";

            foreach (Symbol[] line in game.Board.GameBoard)
            {
                debug += line[i];
            }

            Debug.Log(debug);
        }
    }
}
