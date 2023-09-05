using System;
using UnityEngine;

public class SymbolBehaviour : MonoBehaviour
{
    public Symbol symbolId;

    private bool animActive = false;
    private float animTime = 0.5f;
    private float timer = 0.0f;


    private void Update()
    {
        timer += Time.deltaTime;
        
        if (animActive)
        {
            Scale();
            animActive = false;
        }

        if (timer >= animTime)
        {
            FinishAnim();
            enabled = false;
        }
    }

    public void StartAnim()
    {
        animActive = true;
        enabled = true;
        timer = 0.0f;
    }

    private void Scale()
    {
        transform.localScale *= 0.5f;
    }

    private void FinishAnim()
    {
        transform.localScale = Vector3.one;
    }
}
