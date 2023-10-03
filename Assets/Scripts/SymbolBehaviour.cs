using System;
using UnityEngine;

public class SymbolBehaviour : MonoBehaviour
{
    public Symbol symbolId;
    public string trigger = "";

    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartAnim(bool isExpandingSymbol = false)
    {
        animator.SetTrigger(trigger);

        if (isExpandingSymbol)
        {
            return;
        }

        spriteRenderer.sortingOrder = 5;
    }

    public void StopAnim(bool isExpandingSymbol = false)
    {
        animator.SetTrigger("exit");
        animator.ResetTrigger(trigger);

        if (isExpandingSymbol)
        {
            return;
        }

        spriteRenderer.sortingOrder = 1;
    }
}
