using Newtonsoft.Json;

namespace ConsoleBank
{
    public static class LoggerServices
    {
        public static void LogError(string message)
        {
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "ErrorLog.txt");
            Directory.CreateDirectory(directoryPath);
            string errorToJson = JsonConvert.SerializeObject(message, Formatting.Indented);
            File.WriteAllText(filePath, errorToJson);
        }
    }
}
