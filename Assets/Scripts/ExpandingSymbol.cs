using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manage expanding symbol animations.
/// </summary>
public class ExpandingSymbol : MonoBehaviour
{
    public GameObject[] reelParents;
    public GameObject ExpandingSymbolLogo;
    public Sprite[] goldenSymbols;
    public ShowLine lines;
    public bool expandingAnimationRunning = false;

    private Sprite expandingSymbol;


    // Show expanding symbol one by one on each reel that had expanding symbol hit.
    public IEnumerator PlayExpandingSymbols(List<int> expandingSymbolReels)
    {
        expandingAnimationRunning = true;

        foreach (int reel in expandingSymbolReels)
        {
            foreach (SpriteRenderer render in reelParents[reel].GetComponentsInChildren<SpriteRenderer>())
            {
                render.enabled = true;
                yield return new WaitForSeconds(0.25f);
            }
        }

        // After expanding symbol are visible show all 10 lines.
        yield return StartCoroutine(lines.ShowExpandingLines());

        // Hide symbol again.
        HideExpandingSymbols(expandingSymbolReels);
    }

    // Get active expanding symbol and fill all sprite renderers with it sprite.
    public void GetExpandingSymbol(Symbol expandingSymbol)
    {
        this.expandingSymbol = expandingSymbol switch
        {
            Symbol.Ten => goldenSymbols[0],
            Symbol.Jack => goldenSymbols[1],
            Symbol.Queen => goldenSymbols[2],
            Symbol.King => goldenSymbols[3],
            Symbol.Ace => goldenSymbols[4],
            Symbol.Pafka => goldenSymbols[5],
            Symbol.Seire => goldenSymbols[6],
            Symbol.Mihu => goldenSymbols[7],
            Symbol.Rolts => goldenSymbols[8],
            _ => null,
        };

        FillExpandingSymbols();
    }

    private void FillExpandingSymbols()
    {
        foreach (GameObject reel in reelParents)
        {
            foreach (SpriteRenderer renderer in reel.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.sprite = expandingSymbol;
            }
        }

        ExpandingSymbolLogo.GetComponent<SpriteRenderer>().sprite = expandingSymbol;
    }

    private void HideExpandingSymbols(List<int> expandingSymbolReels)
    {
        foreach (int reel in expandingSymbolReels)
        {
            foreach (SpriteRenderer render in reelParents[reel].GetComponentsInChildren<SpriteRenderer>())
            {
                render.enabled = false;
            }
        }

        expandingAnimationRunning = false;
    }
}
