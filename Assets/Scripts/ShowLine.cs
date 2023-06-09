using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : MonoBehaviour
{
    public GameManager gameManager;

    private GameLine[] lines;


    private void Awake()
    {
        lines = GetComponentsInChildren<GameLine>();
    }

    private void OnEnable()
    {
        gameManager.ShowLines += ActivateLineAfterWin;
    }

    private void OnDisable()
    {
        gameManager.ShowLines -= ActivateLineAfterWin;
    }

    private void ActivateLineAfterWin(List<LineHit> lines)
    {
        StartCoroutine(ActivateLine(lines));
    }

    private IEnumerator ActivateLine(List<LineHit> winLines)
    {
        foreach (LineHit lineHit in winLines)
        {
            lines[lineHit.LineId - 1].spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.5f);
            lines[lineHit.LineId - 1].spriteRenderer.enabled = false;
        }
    }
}
