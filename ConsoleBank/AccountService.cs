using Newtonsoft.Json;

namespace ConsoleBank
{
    public class AccountService
    {
        public static async Task<string> CreateAccount(Account account)
        {
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files\";
            string filePath = Path.Combine(directoryPath, "Accounts.txt");
            Directory.CreateDirectory(directoryPath);
            List<Account> accounts = await GetAllAccountAsync();
            if(accounts == null || accounts.Count == 0) accounts = new List<Account>();
            accounts.Add(account);
            string accountsToJson = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, accountsToJson);
            return $"Account successfully created for {account.FirstName + " " + account.LastName}. Please copy your account number {account.AccountNumber}".ToString();
        }

        public static async Task<Account> GetAccountAsync(string accountNumber) 
        {
            var accounts = await GetAllAccountAsync();
            var account = accounts.FirstOrDefault(account=>account.AccountNumber==accountNumber);
            return account;
        }

        public static async Task<List<Account>> GetAllAccountAsync()
        {
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "Accounts.txt");
            string accountsString;
            List<Account> accounts;
            accountsString = File.ReadAllText(filePath);
            accounts = JsonConvert.DeserializeObject<List<Account>>(accountsString);
            return accounts;
        }
    }
}
