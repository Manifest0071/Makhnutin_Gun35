namespace SocialCasino.Services
{
    public interface ISaveLoadService
    {
        void SaveData<T>(T data, string identifier);
        T LoadData<T>(string identifier);
        bool Exists(string identifier);
    }
}