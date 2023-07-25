using Newtonsoft.Json;

namespace ConsoleBank
{
    public static class TransactionServices
    {
        public static async Task<string> TransferAsync(Account userAccount, string receiversAccountNumber)
        {

            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "Accounts.txt");
            var accounts = await AccountService.GetAllAccountAsync();
            Console.WriteLine("Enter the amount you wish to transfer");
            double.TryParse(Console.ReadLine(), out var amount);
            var receiver = await AccountService.GetAccountAsync(receiversAccountNumber);
            if (userAccount.IsCurrent && userAccount.AccountBalance < (0 + amount) ||
                userAccount.IsSavings && userAccount.AccountBalance < (1000 + amount))
            {
                return $"Poor man, stop whining yourself. Your present account balance is #{userAccount.AccountBalance}".ToString();
            }

            userAccount.AccountBalance -= amount;
            receiver.AccountBalance += amount;
            string jsonAccounts = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, jsonAccounts);
            return ($"Ajee! rich child. Transaction successful.\n" +
                $"The sum of {amount} was transfered to {receiver.AccountNumber}; {receiver.FirstName} + {receiver.LastName}\n" +
                $" New account balance is #{userAccount.AccountBalance}").ToString();
        }

        public static async Task<string> DepositAsync(Account userAccount)
        {
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "Accounts.txt");
            var accounts = await AccountService.GetAllAccountAsync();
            Console.WriteLine("Enter the amount you wish to deposit");
            double.TryParse(Console.ReadLine(), out var amount);
            userAccount.AccountBalance += amount;
            string jsonAccounts = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, jsonAccounts);
            return ($"Ajee! rich child. Transaction successful.\n" +
                $"The sum of {amount} was deposited to your account").ToString();
        }

        public static async Task<string> WithdrawAsync(Account userAccount)
        {
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "Accounts.txt");
            var accounts = await AccountService.GetAllAccountAsync();
            Console.WriteLine("Enter the amount you wish to withdraw");
            double.TryParse(Console.ReadLine(), out var amount);
            if (userAccount.IsCurrent && userAccount.AccountBalance < (0 + amount) ||
                userAccount.IsSavings && userAccount.AccountBalance < (1000 + amount))
            {
                return $"Poor man, stop whining yourself. Your present account balance is #{userAccount.AccountBalance}".ToString();
            }
            userAccount.AccountBalance -= amount;
            string jsonAccounts = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, jsonAccounts);
            return ($"Ajee! rich child. Transaction successful.\n" +
                $"The sum of {amount} was deposited to your account").ToString();
        }

        public static string CheckBalanceAsync(Account userAccount) 
        {
            return $"Your balance is {userAccount.AccountBalance}";
        }
    }
}
