using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Show game lines.
/// </summary>
public class ShowLine : MonoBehaviour
{
    public GameManager gameManager;

    private GameLine[] lines;


    private void Awake()
    {
        lines = GetComponentsInChildren<GameLine>();
    }

    // Show each line that has a win on it after reels have stopped.
    private void OnEnable()
    {
        gameManager.ShowLines += ActivateLineAfterWin;
    }

    private void OnDisable()
    {
        gameManager.ShowLines -= ActivateLineAfterWin;
    }

    public void ActivateLineAfterWin(List<LineHit> lines)
    {
        StartCoroutine(ActivateLines(lines));
    }

    public IEnumerator ActivateLines(List<LineHit> winLines)
    {
        foreach (LineHit lineHit in winLines)
        {
            lines[lineHit.LineId - 1].spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.5f);
            lines[lineHit.LineId - 1].spriteRenderer.enabled = false;
        }

        // These need to be checked here to play animations after lines are shown.
        //gameManager.FreespinCheck(); // After showing win lines, check if player won freespins.
        //gameManager.CheckExpandingSymbol(); // Also check if expanding needs to play expanding symbol animations.
    }

    // Show all lines for a short time after expanding symbol animation is completed.
    public IEnumerator ShowExpandingLines()
    {
        foreach (GameLine line in lines)
        {
            line.spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.25f);

        foreach (GameLine line in lines)
        {
            line.spriteRenderer.enabled = false;
        }
    }
}
