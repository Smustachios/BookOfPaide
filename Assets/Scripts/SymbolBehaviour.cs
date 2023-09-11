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

    public void StartAnim()
    {
        animator.SetTrigger(trigger);
        spriteRenderer.sortingOrder = 5;
    }

    public void StopAnim()
    {
        animator.SetTrigger("exit");
        animator.ResetTrigger(trigger);
        spriteRenderer.sortingOrder = 1;
    }
}
