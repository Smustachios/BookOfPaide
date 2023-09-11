using UnityEngine;


/// <summary>
/// Gets all active symbols that player sees from the reel.
/// </summary>
public class ActiveSymbols : MonoBehaviour
{
    [SerializeField] private GameObject reel;

    private SymbolBehaviour[] reelSymbols;
    
    
    // Gets all symbols at the beginning of the spin.
    // Gets symbols with virtual spin data. All the symbols on the reel must be in the correct order.
    public void GetActiveSymbols(int randomReelSpot)
    {
        reelSymbols = new SymbolBehaviour[3];
        
        for (int i = -1; i <= 1; i++)
        {
            reelSymbols[i + 1] = reel.transform.GetChild(randomReelSpot - i).GetComponent<SymbolBehaviour>();
        }
    }

    // Gets only win symbol. Each win line uses its reel pos to take win symbol.
    public SymbolBehaviour GetWinSymbol(int symbolPos)
    {
        return reelSymbols[symbolPos];
    }

    // Get book for free spin start anim. Return null if no books.
    public SymbolBehaviour GetBookSymbol()
    {
        foreach (SymbolBehaviour sym in reelSymbols)
        {
            if (sym.symbolId == Symbol.Book)
            {
                return sym;
            }
        }

        return null;
    }
}
