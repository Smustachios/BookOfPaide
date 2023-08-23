using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Use to construct or destroy reels in the scene.
/// </summary>
public class ReelConstructor : MonoBehaviour
{
    public int reelId = -1;
    public int nOfBottomSymbols = 9;
    public float placementOffset = 3.0f;
    public float animationOffset;
    public float positionTracker = -3f;


    public void MakeReel(GameObject[] gameSymbols, bool isBonusReel)
    {
        positionTracker = -3;
        
        Reel virtualReel = isBonusReel ? new Reels().BonusReels[reelId] : new Reels().GameReels[reelId];
        List<GameObject> mainReel = new List<GameObject>();
        
        // Main symbols.
        foreach (Symbol symbol in virtualReel.ReelSymbols)
        {
            GameObject gameSymbol = Instantiate(gameSymbols[(int)symbol], transform.position + 
                new Vector3(0, positionTracker), transform.rotation, transform);
            positionTracker += placementOffset;
            
            mainReel.Add(gameSymbol);
        }
        
        // Bottom symbols.
        positionTracker = -6;
        int symbolTracker = virtualReel.ReelSymbols.Length;
        
        for (int i = 0; i < nOfBottomSymbols; i++)
        {
            Instantiate(mainReel[symbolTracker - 1], transform.position + new Vector3(0, positionTracker), transform.rotation, transform);
            positionTracker -= placementOffset;
            symbolTracker--;
        }
    }
    
    public void MakeBaseReel(GameObject[] gameSymbols)
    {
        Reel baseReel = new Reels().GameReels[reelId];

        for (int i = 0; i < 3; i ++)
        {
            if (i == 2)
            {
                positionTracker = (-baseReel.ReelSymbols.Length * 3) - 3;
            }
            foreach (Symbol symbol in baseReel.ReelSymbols)
            {
                GameObject gameSymbol = Instantiate(gameSymbols[(int)symbol], transform.position + new Vector3(0, positionTracker), transform.rotation, transform);
                positionTracker += placementOffset;
            }
        }
    }

    public void MakeBonusReel(GameObject[] gameSymbols)
    {
        Reel bonusReel = new Reels().BonusReels[reelId];

        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                positionTracker = (-bonusReel.ReelSymbols.Length * 3) - 3;
            }
            foreach (Symbol symbol in bonusReel.ReelSymbols)
            {
                GameObject gameSymbol = Instantiate(gameSymbols[(int)symbol], transform.position + new Vector3(0, positionTracker), transform.rotation, transform);
                positionTracker += placementOffset;
            }
        }
    }

    public void MakeExpandingReel(GameObject[] gameSymbols)
    {
        Reel expandingReel = Reels.expandingSymbolReel;

        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                positionTracker = (-expandingReel.ReelSymbols.Length * 5);
            }
            foreach (Symbol symbol in expandingReel.ReelSymbols)
            {
                GameObject gameSymbol = Instantiate(gameSymbols[(int)symbol], transform.position + new Vector3(0, positionTracker), transform.rotation, transform);
                SpriteRenderer spriteRenderer = gameSymbol.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 5;
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
