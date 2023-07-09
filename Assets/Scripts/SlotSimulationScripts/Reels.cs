using System;

/// <summary>
/// Class for different Book of Paide reels data and methods.
/// </summary>
public class Reels
{
    public Reel[] GameReels { get; private set; }
    public Reel[] BonusReels { get; private set; }

    public static Reel expandingSymbolReel = new(Symbol.Pafka, Symbol.Queen, Symbol.Mihu, Symbol.Rolts, Symbol.Seire, Symbol.King, Symbol.Pafka, Symbol.Ten, Symbol.Seire, Symbol.Rolts, Symbol.Pafka, Symbol.Jack, Symbol.Ace, Symbol.King, Symbol.Mihu, Symbol.Jack, Symbol.Seire, Symbol.Jack, Symbol.Queen, Symbol.Rolts, Symbol.Ace, Symbol.Queen, Symbol.Ten, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Mihu, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Mihu, Symbol.Ten, Symbol.Queen);

    private readonly Reel reelOne = new(Symbol.King, Symbol.Jack, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Pafka, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Ace, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
    private readonly Reel reelTwo = new(Symbol.Ace, Symbol.Book, Symbol.King, Symbol.Jack, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Ace, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Pafka, Symbol.Queen, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Rolts, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Ace, Symbol.Ten, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen);
    private readonly Reel reelThree = new(Symbol.Ace, Symbol.Queen, Symbol.Jack, Symbol.Seire, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Rolts, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Ace, Symbol.Mihu, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.Ace, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Mihu, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen, Symbol.King);
    private readonly Reel reelFour = new(Symbol.Ten, Symbol.Jack, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Seire, Symbol.Queen, Symbol.Jack, Symbol.Ten, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Book, Symbol.Jack, Symbol.Queen);
    private readonly Reel reelFive = new(Symbol.Queen, Symbol.Jack, Symbol.Mihu, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Rolts, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Ten, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Queen, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);

    private readonly Reel bonusReelOne = new(Symbol.Jack, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Pafka, Symbol.Seire, Symbol.Book, Symbol.Jack, Symbol.Ten, Symbol.Ace, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
    private readonly Reel bonusReelTwo = new(Symbol.Ace, Symbol.Book, Symbol.King, Symbol.Jack, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Book, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Ace, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Pafka, Symbol.Book, Symbol.Queen, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Rolts, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Ace, Symbol.Ten, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen);
    private readonly Reel bonusReelThree = new(Symbol.Ace, Symbol.Queen, Symbol.Jack, Symbol.Seire, Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Rolts, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Ace, Symbol.Mihu, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Mihu, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen, Symbol.King);
    private readonly Reel bonusReelFour = new(Symbol.Jack, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Seire, Symbol.Book, Symbol.Queen, Symbol.Jack, Symbol.Ten, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Book, Symbol.Jack, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Book, Symbol.Jack, Symbol.Queen);
    private readonly Reel bonusReelFive = new(Symbol.Queen, Symbol.Jack, Symbol.Book, Symbol.Mihu, Symbol.King, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Rolts, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Ten, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Queen, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);


    public Reels()
    {
        GameReels = new Reel[] { reelOne, reelTwo, reelThree, reelFour, reelFive };
        BonusReels = new Reel[] { bonusReelOne, bonusReelTwo, bonusReelThree, bonusReelFour, bonusReelFive };
    }

    // Takes reel and returns 3 symbols from random spot of that reel. One above and one below that random spot.
    // Also gives that random integer where sybols are taken.
    public Symbol[] GetRandomReelSymbols(Reel reel, out int randomReelSpot)
    {
        Random rng = new();

        randomReelSpot = rng.Next(1, reel.ReelSymbols.Length - 1);

        return new Symbol[] { reel.ReelSymbols[randomReelSpot + 1], reel.ReelSymbols[randomReelSpot], reel.ReelSymbols[randomReelSpot - 1] };
    }

    // Return random spot and symbol from expanding reel.
    public static Symbol GetRandomExpandingSymbol(out int randomReelSpot)
    {
        Random rng = new();

        randomReelSpot = rng.Next(0, expandingSymbolReel.ReelSymbols.Length);

        return expandingSymbolReel.ReelSymbols[randomReelSpot];
    }

    // Test reel for freespins. Has alot of books on reels to garantee freespins on every spin.
/*
private readonly Reel reelOne = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts);
private readonly Reel reelTwo = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts);
private readonly Reel reelThree = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts);
private readonly Reel reelFour = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts);
private readonly Reel reelFive = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Ace, Symbol.Mihu, Symbol.Book, Symbol.Seire, Symbol.Rolts);
*/

// Original reels for base game!!
/*
private readonly Reel reelOne = new(Symbol.King, Symbol.Jack, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Pafka, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Ace, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
private readonly Reel reelTwo = new(Symbol.Ace, Symbol.Book, Symbol.King, Symbol.Jack, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Ace, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Pafka, Symbol.Queen, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Rolts, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Ace, Symbol.Ten, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen);
private readonly Reel reelThree = new(Symbol.Ace, Symbol.Queen, Symbol.Jack, Symbol.Seire, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Rolts, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Ace, Symbol.Mihu, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.Ace, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Mihu, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen, Symbol.King);
private readonly Reel reelFour = new(Symbol.Ten, Symbol.Jack, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Seire, Symbol.Queen, Symbol.Jack, Symbol.Ten, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Book, Symbol.Jack, Symbol.Queen);
private readonly Reel reelFive = new(Symbol.Queen, Symbol.Jack, Symbol.Mihu, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Rolts, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Ten, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Queen, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
*/

// Original bonus reels
/*
private readonly Reel bonusReelOne = new(Symbol.King, Symbol.Jack, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Pafka, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Ace, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
private readonly Reel bonusReelTwo = new(Symbol.Ace, Symbol.Book, Symbol.King, Symbol.Jack, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Ace, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Pafka, Symbol.Queen, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Rolts, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Ace, Symbol.Ten, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen);
private readonly Reel bonusReelThree = new(Symbol.Ace, Symbol.Queen, Symbol.Jack, Symbol.Seire, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Rolts, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Ace, Symbol.Mihu, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.Ace, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Mihu, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen, Symbol.King);
private readonly Reel bonusReelFour = new(Symbol.Ten, Symbol.Jack, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Seire, Symbol.Queen, Symbol.Jack, Symbol.Ten, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Book, Symbol.Jack, Symbol.Queen);
private readonly Reel bonusReelFive = new(Symbol.Queen, Symbol.Jack, Symbol.Mihu, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Rolts, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Ten, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Queen, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
*/

}
