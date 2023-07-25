using ConsoleBank;
Console.WriteLine("Welcome to Console Bank, Enter 1 to Create a user account, enter 2 to login, enter any other button to exit");
byte.TryParse(Console.ReadLine(), out byte option);
switch (option) 
{
    case 1:
        try
        {
            var user = ServiceExtension.CreateUser();
            var result = await UserService.CreateUser(user);
            Console.WriteLine(result);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); LoggerServices.LogError(ex.ToString()); }
        break;
    case 2:
        try
        {
            Console.Write("Please enter username: ");
            var userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();
            if (userName == null || password == null) throw new Exception("Username or password cannot be null");
            var userAccount = UserService.GetUser(userName, password);
            if (userAccount == null) throw new Exception("Invalid username or pasword");
            ExtendedServiceExtensions.AccountUserServices();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); LoggerServices.LogError(ex.ToString()); }
        break;
}