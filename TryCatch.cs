
namespace ConsoleApp
{
    public class TryCatch
    {
        public static async Task Run()
        {
            int emailReturnValue;
            try
            {
                var validUser = await ValidateUser("A");
                try
                {
                    var savedUser = await SaveUser(validUser);
                    try
                    {
                        emailReturnValue = await SendEmail(savedUser);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static async Task<User> ValidateUser(string username)
        {
            Console.WriteLine($"ValidateUser: {username}");

            if (username.Contains("A"))
            {
                throw new Exception("username includes illegal char");

            }
            return await Task.FromResult(new User(username));
        }

        public static async Task<SavedUsed> SaveUser(User user)
        {
            Console.WriteLine($"SaveUser: {user.Name}");

            if (user.Name.Contains("B"))
            {
                throw new Exception("Failed when saved user");

            }
            return await Task.FromResult(new SavedUsed(user));
        }

        public static async Task<int> SendEmail(SavedUsed user)
        {
            Console.WriteLine($"Sending email: {user.User.Name}");

            if (user.User.Name.Contains("C"))
            {
                throw new Exception("Failed when saving user");

            }
            return await Task.FromResult(1);
        }

        public class User(string name)
        {
            public string Name { get; set; } = name;
        }

        public class SavedUsed(User user)
        {
            public User User { get; set; } = user;
        }
    }
}
