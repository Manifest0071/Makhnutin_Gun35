using System;
using System.Collections.Generic;
using System.Linq;
using SocialCasino.Models;

namespace SocialCasino.Games
{
    public class BlackjackGame : CasinoGameBase
    {
        private readonly int _cardsCount;
        private Queue<Card> _deck;

        public BlackjackGame(int cardsCount)
        {
            _cardsCount = cardsCount;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            var deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            deck = deck.OrderBy(x => Guid.NewGuid()).ToList();
            _deck = new Queue<Card>(deck);
        }

        public override void PlayGame(PlayerProfile player, int bet)
        {
            var playerHand = new List<Card> { _deck.Dequeue(), _deck.Dequeue() };
            var dealerHand = new List<Card> { _deck.Dequeue(), _deck.Dequeue() };

            int playerScore = CalculateScore(playerHand);
            int dealerScore = CalculateScore(dealerHand);

            while (playerScore == dealerScore && playerScore < 21)
            {
                playerHand.Add(_deck.Dequeue());
                dealerHand.Add(_deck.Dequeue());
                playerScore = CalculateScore(playerHand);
                dealerScore = CalculateScore(dealerHand);
            }

            if (playerScore > 21 && dealerScore > 21)
            {
                OnDrawInvoke();
            }
            else if (playerScore <= 21 && (dealerScore > 21 || playerScore > dealerScore))
            {
                player.Balance += bet;
                OnWinInvoke();
            }
            else if (dealerScore <= 21 && (playerScore > 21 || dealerScore > playerScore))
            {
                player.Balance -= bet;
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        private int CalculateScore(List<Card> hand)
        {
            return hand.Sum(c => (int)c.Rank);
        }
    }
}