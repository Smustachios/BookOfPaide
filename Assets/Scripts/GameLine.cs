using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLine : MonoBehaviour
{
    public int lineID;
    public SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
