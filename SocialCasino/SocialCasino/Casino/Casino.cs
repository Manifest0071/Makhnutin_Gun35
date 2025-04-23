using System;
using SocialCasino.Models;
using SocialCasino.Services;
using SocialCasino.Games;

namespace SocialCasino.Casino
{
    public class CasinoGame : IGame
    {
        private readonly ISaveLoadService _saveLoadService;
        private PlayerProfile _player;

        public CasinoGame(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void StartGame()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

                if (_saveLoadService.Exists(name))
            {
                _player = _saveLoadService.LoadData<PlayerProfile>(name);
                Console.WriteLine($"Welcome back, {_player.Name}. Balance: {_player.Balance}");
            }
                else
            {
                _player = new PlayerProfile { Name = name };
                Console.WriteLine($"New profile created for {_player.Name}. Balance: {_player.Balance}");
            }

                while (true)
            {
                if (_player.Balance <= 0)
                {
                    Console.WriteLine("No money? Kicked!");
                break;
                }

            string choice;
                while (true)
                {
                    Console.WriteLine("\nChoose a game: 1. Blackjack 2. Dice 3. Exit");
                    choice = Console.ReadLine();

                 if (choice == "1" || choice == "2" || choice == "3")
                        break;

                    Console.WriteLine("Некорректно введены данные. Пожалуйста, выберите 1, 2 или 3.");
                }

                CasinoGameBase game = choice switch
                {
                    "1" => new BlackjackGame(4),
                    "2" => new DiceGame(2, 1, 6),
                    _ => null
                };

                if (game == null)
                {
                    Console.WriteLine("Bye!");
                    _saveLoadService.SaveData(_player, _player.Name);
                 break;
                }

                game.OnWin += () => Console.WriteLine("You win!");
                game.OnLoose += () => Console.WriteLine("You lose!");
                game.OnDraw += () => Console.WriteLine("Draw!");

                Console.Write("Enter your bet: ");
                int bet = int.Parse(Console.ReadLine());
                if (bet > _player.Balance)
                {
                    Console.WriteLine("Not enough balance.");
                 continue;
                }

                game.PlayGame(_player, bet);

                if (_player.Balance > int.MaxValue)
                {
                    _player.Balance = int.MaxValue;
                    Console.WriteLine("You broke the casino! They’ll build a new one!");
                }
                else if (_player.Balance > 3000)
                {
                    _player.Balance /= 2;
                    Console.WriteLine("You wasted half of your bank money in casino’s bar");
                }

                Console.WriteLine($"Balance: {_player.Balance}");
            }
        }
    }
}