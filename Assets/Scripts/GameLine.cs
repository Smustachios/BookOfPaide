using UnityEngine;
using TMPro;


/// <summary>
/// Line component in the scene. Each line has uniqe id and can be turned on and off with spriterender.
/// </summary>
public class GameLine : MonoBehaviour
{
    public int lineID;
    public SpriteRenderer spriteRenderer;
    public TextMeshPro smallWinBar;
    public TextMeshPro bigWinBar;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
