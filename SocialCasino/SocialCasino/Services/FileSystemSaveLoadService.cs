using System.IO;
using System.Text.Json;

namespace SocialCasino.Services
{
    public class FileSystemSaveLoadService : ISaveLoadService
    {
        private readonly string _directoryPath;

        public FileSystemSaveLoadService(string directoryPath)
        {
            _directoryPath = directoryPath;

            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
        }

        public void SaveData<T>(T data, string identifier)
        {
            File.WriteAllText(Path.Combine(_directoryPath, identifier + ".txt"), JsonSerializer.Serialize(data));
        }

        public T LoadData<T>(string identifier)
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(Path.Combine(_directoryPath, identifier + ".txt")));
        }

        public bool Exists(string identifier)
        {
            return File.Exists(Path.Combine(_directoryPath, identifier + ".txt"));
        }
    }
}
