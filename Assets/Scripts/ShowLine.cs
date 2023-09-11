using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Show game lines.
/// </summary>
public class ShowLine : MonoBehaviour
{
    public GameManager gameManager;
    
    [SerializeField] private float lineActivationTime = 5f;
    [SerializeField] private GameLine[] lines;
    [SerializeField] private GameObject symbolAlphaMask;
    
    private GameLine activeLine;
    private List<GameLine> activeLines;
    private List<LineHit> virtualWinLines;
    private float timer;
    private int lineQueCounter;



    // Disable each line at the start of the game. Each line will be activated when its needs to play its anim.
    private void Awake()
    {
        foreach (var line in lines)
        {
            line.SetUp();
            line.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > lineActivationTime)
        {
            activeLine.Hide();
            ChangeActiveLine();
        }
    }

    // Make a que of win lines and start update to show them.
    public void ActivateLines(List<LineHit> winLines, ActiveSymbols[] reelSymbols)
    {
        if (winLines.Count <= 0)
        {
            StartCoroutine(gameManager.FinishSpinCoroutine());
            return;
        }
        
        virtualWinLines = winLines;
        activeLines = new List<GameLine>();
        lineQueCounter = 0;
        
        foreach (LineHit lineHit in winLines)
        {
            activeLines.Add(lines[lineHit.LineId - 1]);
        }

        for (int i = 0; i < activeLines.Count; i++)
        {
            LineHit lineHit = winLines[i];
            
            for (int j = 0; j < lineHit.WinId; j++)
            {
                activeLines[i].AddWinSymbol(reelSymbols[j].GetWinSymbol(activeLines[i].symbolPositions[j]));
            }
        }
        
        ChangeActiveLine();
        symbolAlphaMask.SetActive(true);
        
        enabled = true;
    }

    // Show all lines for a short time after expanding symbol animation is completed.
    public IEnumerator ShowExpandingLines()
    {
        foreach (GameLine line in lines)
        {
            line.Show();
            yield return new WaitForSeconds(0.75f);
        }

        yield return new WaitForSeconds(0.25f);

        foreach (GameLine line in lines)
        {
            line.Hide();
        }
    }

    // Show next active line in the win lines que. Finish spin if nothing left in the que.
    private void ChangeActiveLine()
    {
        if (lineQueCounter <= virtualWinLines.Count - 1)
        {
            timer = 0.0f;
            activeLine = activeLines[lineQueCounter];
            activeLine.Show(virtualWinLines[lineQueCounter]);
            lineQueCounter++;
        }
        else
        {
            ClearAllWinSymbols();
            symbolAlphaMask.SetActive(false);
            enabled = false;
            StartCoroutine(gameManager.FinishSpinCoroutine());
        }
    }

    private void ClearAllWinSymbols()
    {
        foreach (GameLine gameLine in lines)
        {
            gameLine.ClearWinSymbols();
        }
    }
}
