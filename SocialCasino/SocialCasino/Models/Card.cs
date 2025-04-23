namespace SocialCasino.Models
{
    public enum Suit { Diamonds, Hearts, Clubs, Spades }
    public enum Rank { Six = 6, Seven, Eight, Nine, Ten, Jack = 10, Queen = 10, King = 10, Ace = 11 }

    public readonly struct Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
