
namespace ConsoleApp
{
    public class TryCatch
    {
        public static void Run()
        {
            try
            {
                var validUser = ValidateUser("A");
                var savedUser = SaveUser(validUser);
                int emailReturnValue = SendEmail(savedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static User ValidateUser(string username)
        {
            Console.WriteLine($"ValidateUser: {username}");

            if (username.Contains("A"))
            {
                throw new Exception("username includes illegal char");

            }
            return new User(username);
        }

        public static SavedUsed SaveUser(User user)
        {
            Console.WriteLine($"SaveUser: {user.Name}");

            if (user.Name.Contains("B"))
            {
                throw new Exception("Failed when saved user");

            }
            return new SavedUsed(user);
        }

        public static int SendEmail(SavedUsed user)
        {
            Console.WriteLine($"Sending email: {user.User.Name}");

            if (user.User.Name.Contains("C"))
            {
                throw new Exception("Failed when saving user");

            }
            return 1;
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
