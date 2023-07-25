namespace ConsoleBank
{
    public static class ServiceExtension
    {
        public static User CreateUser()
        {
            repeat:
            Console.WriteLine("Enter Username");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();
            if(userName == null || password == null) { throw new Exception("Username or password was null"); goto repeat; }

            User newUser = new User
            {
                UserName = userName,
                Password = password,
            };
            return newUser;
        }

        public static Account CreateAccount()
        {
            while (true)
            {
                Console.WriteLine("Please enter firstname");
                var firstName = Console.ReadLine();
                if (firstName != null)
                    Console.WriteLine("Please enter lastname");
                var lastName = Console.ReadLine();
                if (lastName != null)
                    Console.WriteLine("Enter NIN");
                var NIN = Console.ReadLine();
                if (NIN != null)
                    Console.WriteLine("Select account type\n Enter 1 to Create a SAVINGS ACCOUNT\n Enter 2 to create CURRENT ACCOUNT");
                byte.TryParse(Console.ReadLine(), out byte option);
                switch (option) 
                {
                    case 1:
                        Console.WriteLine("Enter initial deposit of above #1,000");
                        double.TryParse(Console.ReadLine(), out double initialDeposit);
                        if (initialDeposit >= 1000)
                        {
                            Account account = new()
                            {
                                AccountNumber = GenerateAccountNumber(),
                                FirstName = firstName,
                                LastName = lastName,
                                IsSavings = true,
                                IsCurrent = false,
                                AccountBalance = initialDeposit,
                                NIN = NIN
                            };
                            return account;
                        } 
                        break;
                    case 2:
                        Console.WriteLine("Enter initial deposit");
                        double.TryParse(Console.ReadLine(), out double initialAmount);
                        if (initialAmount >= 0)
                        {
                            Account account = new()
                            {
                                AccountNumber = GenerateAccountNumber(),
                                FirstName = firstName,
                                LastName = lastName,
                                IsSavings = true,
                                IsCurrent = false,
                                AccountBalance = initialAmount,
                                NIN = NIN
                            };
                            return account;
                        }
                        break;
                    default:
                        break;
                }

            }       

            string GenerateAccountNumber()
            {
                Random random = new Random();
                var number = random.Next(0, 1000000000);
                string AccountNumber = "5" + number.ToString();
                return AccountNumber;
            }
        }
    }
}