using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : MonoBehaviour
{
    public GameManager gameManager;
    public int LineId;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        foreach (LineHit line in lines)
        {
            if (line.LineId == LineId)
            {
                StartCoroutine(ActivateLine());
            }
        }
    }

    private IEnumerator ActivateLine()
    {
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
    }
}
