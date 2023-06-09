using UnityEngine;

public class ReelConstructor : MonoBehaviour
{
    public int reelId = -1;
    public float placementOffset = 3.0f;
    public float animationOffset;

    private float positionTracker = -3f;


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

    public void DestroyReel()
    {
        foreach (var symbol in GetComponentsInChildren<SpriteRenderer>())
        {
            Destroy(symbol.gameObject);
        }
    }
}