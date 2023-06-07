using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelConstructor : MonoBehaviour
{
    public GameManager gameManager;
    public int reelId = -1;
    public float placementOffset = 3.0f;

    private Reel baseReel;
    private Reel bonusReel;
    private float positionTracker = -3f;


    private void Awake()
    {
        Reels allReels = new();
        baseReel = allReels.GameReels[reelId];
        bonusReel = allReels.BonusReels[reelId];

        MakeBaseReel();
    }

    public void MakeBaseReel()
    {
        for (int i = 0; i < 3; i ++)
        {
            if (i == 2)
            {
                positionTracker = (-baseReel.ReelSymbols.Length * 3) - 3;
            }
            foreach (Symbol symbol in baseReel.ReelSymbols)
            {
                GameObject gameSymbol = Instantiate(gameManager.gameSymbols[(int)symbol], transform.position + new Vector3(0, positionTracker), transform.rotation, transform);
                positionTracker += placementOffset;
            }
        }
    }

    public void MakeBonusReel()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                positionTracker = (-bonusReel.ReelSymbols.Length * 3) - 3;
            }
            foreach (Symbol symbol in bonusReel.ReelSymbols)
            {
                GameObject gameSymbol = Instantiate(gameManager.gameSymbols[(int)symbol], transform.position + new Vector3(0, positionTracker), transform.rotation, transform);
                positionTracker += placementOffset;
            }
        }
    }

    public void DestroyReel()
    {
        foreach (var symbol in GetComponentsInChildren<SpriteRenderer>())
        {
            Destroy(symbol.gameObject);
        }
    }
}
