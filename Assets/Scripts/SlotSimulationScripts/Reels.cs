using System;

public class Reels
{
    public Reel[] GameReels { get; private set; }
    public Reel[] BonusReels { get; private set; }

    private static Reel expandingSymbolReel = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts);

    private Reel reelOne = new(Symbol.King, Symbol.Jack, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Pafka, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Ace, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);
    private Reel reelTwo = new(Symbol.Ace, Symbol.Book, Symbol.King, Symbol.Jack, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Ace, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Pafka, Symbol.Queen, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Rolts, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Ace, Symbol.Ten, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen);
    private Reel reelThree = new(Symbol.Ace, Symbol.Queen, Symbol.Jack, Symbol.Seire, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Rolts, Symbol.Seire, Symbol.King, Symbol.Jack, Symbol.Ace, Symbol.Mihu, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.Ace, Symbol.King, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.Jack, Symbol.Mihu, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Book, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Queen, Symbol.King);
    private Reel reelFour = new(Symbol.Ten, Symbol.Jack, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Seire, Symbol.Queen, Symbol.Jack, Symbol.Ten, Symbol.Rolts, Symbol.Mihu, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Ten, Symbol.King, Symbol.Jack, Symbol.Mihu, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.King, Symbol.Ace, Symbol.Jack, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.Book, Symbol.Jack, Symbol.Queen);
    private Reel reelFive = new(Symbol.Queen, Symbol.Jack, Symbol.Mihu, Symbol.King, Symbol.Ten, Symbol.Queen, Symbol.Jack, Symbol.Pafka, Symbol.Ten, Symbol.Seire, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Rolts, Symbol.Book, Symbol.Ten, Symbol.Queen, Symbol.Ace, Symbol.Seire, Symbol.Ten, Symbol.Ace, Symbol.Queen, Symbol.King, Symbol.Jack, Symbol.Pafka, Symbol.Ace, Symbol.Queen, Symbol.Ten, Symbol.Jack, Symbol.Rolts, Symbol.Queen, Symbol.King, Symbol.Ten, Symbol.Ace, Symbol.Jack, Symbol.Ten, Symbol.Queen, Symbol.Seire, Symbol.Pafka, Symbol.Queen, Symbol.Ten, Symbol.King, Symbol.Jack);

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

        return new Symbol[] { reel.ReelSymbols[randomReelSpot + 1], reel.ReelSymbols[randomReelSpot], reel.ReelSymbols[randomReelSpot - 1] };
    }

    public static Symbol GetRandomExpandingSymbol(out int randomReelSpot)
    {
        Random rng = new();

        randomReelSpot = rng.Next(0, expandingSymbolReel.ReelSymbols.Length);

        return expandingSymbolReel.ReelSymbols[randomReelSpot];
    }

    /*
    private Reel reelOne = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelTwo = new(Symbol.Ten, Symbol.Book, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Book, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelThree = new(Symbol.Book, Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelFour = new(Symbol.Ten, Symbol.Jack, Symbol.Queen, Symbol.Book, Symbol.Ace, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    private Reel reelFive = new(Symbol.Book, Symbol.Jack, Symbol.Queen, Symbol.King, Symbol.Ace, Symbol.Book, Symbol.Mihu, Symbol.Pafka, Symbol.Seire, Symbol.Rolts, Symbol.Book);
    */
}
