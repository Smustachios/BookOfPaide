using System;
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
    public SymbolBehaviour[] goldenSymbols;
    public ShowLine lines;

    public float timeBetweenSymbolInit = 0.25f;
    public bool expandingAnimationRunning = false;

    private GameObject expandingSymbol;
    private List<SymbolBehaviour> activeExpandingSymbols;


    // Show expanding symbol one by one on each reel that had expanding symbol hit.
    public void PlayExpandingSymbols(List<int> expandingSymbolReels)
    {
        expandingAnimationRunning = true;

        activeExpandingSymbols = new List<SymbolBehaviour>();

        StartCoroutine(InitializeSymbols(expandingSymbolReels));
    }

    // Get active expanding symbol and fill all sprite renderers with it sprite.
    public void GetExpandingSymbol(Symbol expandingSymbol)
    {
        foreach (SymbolBehaviour prefab in  goldenSymbols)
        {
            if (prefab.symbolId == expandingSymbol)
            {
                this.expandingSymbol = prefab.gameObject;
            }
        }

        ExpandingSymbolLogo.GetComponent<SpriteRenderer>().sprite = this.expandingSymbol.GetComponent<SpriteRenderer>().sprite;
    }

    private IEnumerator InitializeSymbols(List<int> expandingSymbolReels)
    {
        foreach (int reel in expandingSymbolReels)
        {
            for (int i = 3; i >= -3; i -= 3)
            {
                GameObject symbol = Instantiate(expandingSymbol, reelParents[reel].transform.position + new Vector3(0, i),
                    reelParents[reel].transform.rotation, reelParents[reel].transform);

                activeExpandingSymbols.Add(symbol.GetComponent<SymbolBehaviour>());

                yield return new WaitForSeconds(timeBetweenSymbolInit);
            }
        }

        PlayExpandingSymbolAnims();

        // Show all lines to player.
        yield return StartCoroutine(lines.ShowExpandingLines(DestroyActiveSymbols));
    }

    private void PlayExpandingSymbolAnims()
    {
        foreach (SymbolBehaviour symbol in activeExpandingSymbols)
        {
            symbol.StartAnim(true);
        }
    }

    private void DestroyActiveSymbols()
    {
        foreach (SymbolBehaviour symbol in activeExpandingSymbols)
        {
            Destroy(symbol.gameObject);
        }

        expandingAnimationRunning = false;
    }
}
