using UnityEngine;


/// <summary>
/// Line component in the scene. Each line has uniqe id and can be turned on and off with spriterender.
/// </summary>
public class GameLine : MonoBehaviour
{
    public int lineID;
    public SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
