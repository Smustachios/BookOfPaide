using System.Collections.Generic;
using UnityEngine;

public class ActiveSymbols : MonoBehaviour
{
    [SerializeField] private GameObject reel;

    private SymbolBehaviour[] reelSymbols;
    
    
    
    public void GetActiveSymbols(int randomReelSpot)
    {
        reelSymbols = new SymbolBehaviour[3];
        
        for (int i = -1; i <= 1; i++)
        {
            reelSymbols[i + 1] = reel.transform.GetChild(randomReelSpot - i).GetComponent<SymbolBehaviour>();
        }
    }

    public SymbolBehaviour GetWinSymbol(int symbolPos)
    {
        return reelSymbols[symbolPos];
    }
}
