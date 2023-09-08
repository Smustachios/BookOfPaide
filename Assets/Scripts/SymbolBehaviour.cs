using System;
using UnityEngine;

public class SymbolBehaviour : MonoBehaviour
{
    public Symbol symbolId;
    public string trigger = "";

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnim()
    {
        animator.SetTrigger(trigger);
    }

    public void StopAnim()
    {
        animator.SetTrigger("exit");
        animator.ResetTrigger(trigger);
    }
}
