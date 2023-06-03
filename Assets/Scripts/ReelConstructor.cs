using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelConstructor : MonoBehaviour
{
    public int reelId = -1;
    public float placementOffset = 3.0f;

    private GameManager gameManager;
    private Reel gameReel;
    private float positionTracker = -3f;


    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Reels allReels = new();
        gameReel = allReels.GameReels[reelId];

        for (int c = -gameReel.ReelSymbols.Length * 3; c < gameReel.ReelSymbols.Length * 3; c += gameReel.ReelSymbols.Length * 3)
        {
            InitalizeReel(c);
        }
    }

    private void InitalizeReel(float startPos)
    {
        foreach (Symbol symbol in gameReel.ReelSymbols)
        {
            GameObject gameSymbol = Instantiate(gameManager.gameSymbols[(int)symbol],
                transform.position + new Vector3(0, positionTracker + startPos), transform.rotation, transform);
            positionTracker += placementOffset;
        }

        positionTracker = -3;
    }
}
