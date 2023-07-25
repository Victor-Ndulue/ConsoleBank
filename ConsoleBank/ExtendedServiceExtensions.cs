namespace ConsoleBank
{
    public static class ExtendedServiceExtensions
    {
        public static async Task AccountUserServices()
        {
            bool continueServices = true;
            while (continueServices)
            {
                Console.WriteLine("Please Select Services:\n" +
                    "Enter 1 to create an account with us\n" +
                    "Enter 2 to perform transaction services with your account\n" +
                    "Enter any other key to exit the application\n");

                byte.TryParse(Console.ReadLine(), out byte option);
                switch (option)
                {
                    case 1:
                        var account = ServiceExtension.CreateAccount();
                        var accountDetails = await AccountService.CreateAccount(account);
                        Console.WriteLine(accountDetails);
                        break;
                    case 2:
                    repeat:
                        Console.WriteLine("Please enter your account number\n");
                        string accountNumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(accountNumber)) goto repeat;

                        var userAccount = await AccountService.GetAccountAsync(accountNumber);
                        if (userAccount == null)
                        {
                            Console.WriteLine("Account not found. Try again.");
                            break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Please Select Services:\n" +
                                "Enter 1 to Check Balance\n" +
                                "Enter 2 to Deposit funds\n" +
                                "Enter 3 to Withdraw cash\n" +
                                "Enter 4 to Transfer fund to another account\n" +
                                "Enter any other Key to exit\n");

                            byte.TryParse(Console.ReadLine(), out byte input);
                            switch (input)
                            {
                                case 1:
                                    var balanceDetails = TransactionServices.CheckBalanceAsync(userAccount);
                                    Console.WriteLine(balanceDetails);
                                    break;
                                case 2:
                                    var depositDetails = await TransactionServices.DepositAsync(userAccount);
                                    Console.WriteLine(depositDetails);
                                    break;
                                case 3:
                                    var withdrawDetails = await TransactionServices.WithdrawAsync(userAccount);
                                    Console.WriteLine(withdrawDetails);
                                    break;
                                case 4:
                                    Console.WriteLine("Enter recipient's account number");
                                    string receiversAccountNumber = Console.ReadLine();
                                    var transferDetails = await TransactionServices.TransferAsync(userAccount, receiversAccountNumber);
                                    Console.WriteLine(transferDetails);
                                    break;
                                default:
                                    continueServices = false; 
                                    break;
                            }

                            if (!continueServices) break; 
                        }
                        break;
                    default:
                        continueServices = false; 
                        break;
                }
            }
            Console.WriteLine("Goodbye!");
        }

    }
}