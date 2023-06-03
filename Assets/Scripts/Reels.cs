using System;

public class Reels
{
    public Reel[] GameReels { get; private set; }
    public Reel[] BonusReels { get; private set; }

    private static Reel expandingSymbolReel = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts);

    private Reel reelOne = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelTwo = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelThree = new(Symbol.Book, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelFour = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelFive = new(Symbol.Book, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Book, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);

    private Reel bonusReelOne = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel bonusReelTwo = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel bonusReelThree = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel bonusReelFour = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel bonusReelFive = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);



    public Reels()
    {
        GameReels = new Reel[] { reelOne, reelTwo, reelThree, reelFour, reelFive };
        BonusReels = new Reel[] { bonusReelOne, bonusReelTwo, bonusReelThree, bonusReelFour, bonusReelFive };
    }

    public Symbol[] GetRandomReelSymbols(Reel reel, out int randomReelSpot)
    {
        Random rng = new();

        randomReelSpot = rng.Next(1, reel.ReelSymbols.Length - 1);

        return new Symbol[] { reel.ReelSymbols[randomReelSpot - 1], reel.ReelSymbols[randomReelSpot], reel.ReelSymbols[randomReelSpot + 1] };
    }

    public static Symbol GetRandomExpandingSymbol(out int randomReelSpot)
    {
        Random rng = new();

        randomReelSpot = rng.Next(0, expandingSymbolReel.ReelSymbols.Length);

        return expandingSymbolReel.ReelSymbols[randomReelSpot];
    }

    // TEST REELS:
    // new(Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book, Symbol.Book)
    // new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
}
