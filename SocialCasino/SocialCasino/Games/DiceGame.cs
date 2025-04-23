using System.Collections.Generic;
using SocialCasino.Models;

namespace SocialCasino.Games
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _diceCount;
        private readonly int _min;
        private readonly int _max;
        private readonly List<Dice> _playerDices = new();
        private readonly List<Dice> _dealerDices = new();

        public DiceGame(int count, int min, int max)
        {
            _diceCount = count;
            _min = min;
            _max = max;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _playerDices.Clear();
            _dealerDices.Clear();
            for (int i = 0; i < _diceCount; i++)
            {
                _playerDices.Add(new Dice(_min, _max));
                _dealerDices.Add(new Dice(_min, _max));
            }
        }

        public override void PlayGame(PlayerProfile player, int bet)
        {
            int playerTotal = 0, dealerTotal = 0;
            foreach (var dice in _playerDices) playerTotal += dice.Number;
            foreach (var dice in _dealerDices) dealerTotal += dice.Number;

            if (playerTotal > dealerTotal)
            {
                player.Balance += bet;
                OnWinInvoke();
            }
            else if (playerTotal < dealerTotal)
            {
                player.Balance -= bet;
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }
    }
}