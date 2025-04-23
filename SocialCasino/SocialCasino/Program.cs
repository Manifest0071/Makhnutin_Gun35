using SocialCasino.Casino;
using SocialCasino.Games;
using SocialCasino.Services;

namespace SocialCasino
{
    class Program
    {
        static void Main(string[] args)
        {
            ISaveLoadService saveLoadService = new FileSystemSaveLoadService("profiles");
            IGame game = new CasinoGame(saveLoadService);
            game.StartGame();
        }
    }
}
