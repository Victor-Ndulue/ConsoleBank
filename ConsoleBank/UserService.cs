using Newtonsoft.Json;

namespace ConsoleBank
{
    public static class UserService
    {
        public static async Task<string> CreateUser(User user)
        {            
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "Users.txt");            
            Directory.CreateDirectory(directoryPath);
            List<User> users = await GetUsersAsync();
            if(users == null) users = new List<User>();
            users.Add(user);
            string usersToJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, usersToJson);            
            return ($"User account for {user.UserName} has been successfully created").ToString();
        }

        public static  async Task<User> GetUser(string userName, string password)
        {
            List<User> users = await GetUsersAsync();
            var userObject = users.FirstOrDefault(user => user.UserName == userName && user.Password == password);
            if (userObject != null)
            {
                return userObject;
            }
            else { throw new Exception("Invalid username or password"); }
            
        }

        public static async Task<List<User>> GetUsersAsync()
        {
            string directoryPath = @"C:\Users\victor.ndulue\OneDrive - Africa Prudential\source\repos\ConsoleBank\ConsoleBank\Data\Files";
            string filePath = Path.Combine(directoryPath, "Users.txt");
            string usersString;
            List<User> users;
            try
            {
                usersString = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<User>>(usersString);
            }
            catch (Exception ex)
            {
                // Log the exception or output to console for debugging.
                Console.WriteLine("Error occurred during deserialization: " + ex.Message);
                users = null;
            }

            return users;
        }
    }
}
