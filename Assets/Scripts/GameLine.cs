using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// Line component in the scene. Each line has uniqe id and can be turned on and off with spriterender.
/// </summary>
public class GameLine : MonoBehaviour
{
    public int lineID;
    public TextMeshPro smallWinBar;
    public TextMeshPro bigWinBar;
    public int[] symbolPositions;

    private Animator animator;
    private List<SymbolBehaviour> lineWinSymbols;


    
    public void SetUp()
    {
        lineWinSymbols = new List<SymbolBehaviour>();
        animator = GetComponent<Animator>();
    }
    
    public void Show(LineHit lineHitData = null)
    {
        if (lineHitData != null)
        {
            ShowLineWinText(lineHitData);
        }

        gameObject.SetActive(true);
        animator.SetInteger("animId", lineID);
        Debug.Log($"anim id set to: {animator.GetInteger("animId")}");

        foreach (SymbolBehaviour symbol in lineWinSymbols)
        {
            symbol.StartAnim();
        }
    }

    public void Hide()
    {
        smallWinBar.enabled = false;
        bigWinBar.enabled = false;
        animator.SetInteger("animId", 0);
        gameObject.SetActive(false);
    }

    public void AddWinSymbol(SymbolBehaviour winSymbol)
    {
        lineWinSymbols.Add(winSymbol);
    }

    public void ClearWinSymbols()
    {
        lineWinSymbols = new List<SymbolBehaviour>();
    }
    
    private void ShowLineWinText(LineHit data)
    {
        if (data.WinId < 4)
        {
            smallWinBar.text = data.WinMultiplier.ToString();
            smallWinBar.enabled = true;
        }
        else
        {
            bigWinBar.text = data.WinMultiplier.ToString();
            bigWinBar.enabled = true;
        }
    }
}
