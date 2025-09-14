
namespace ConsoleApp
{
    public class IfElseWithNull
    {
        public static void Run()
        {
            int emailReturnValue;

            var validUser = ValidateUser("A");
            if (validUser != null)
            {
                var savedUser = SaveUser(validUser);
                if (savedUser != null)
                {
                    var emailResponse = SendEmail(savedUser);
                    if (emailResponse != null)
                    {
                        emailReturnValue = (int) emailResponse;
                    }
                    else
                    {
                        Console.WriteLine("Failed when saving user");
                    }
                }
                else
                {
                    Console.WriteLine("Failed when saved user");
                }
            }
            else
            {
                Console.WriteLine("username includes illegal char");
            }
        }

        public static User? ValidateUser(string username)
        {
            Console.WriteLine($"ValidateUser: {username}");

            if (username.Contains("A"))
            {
                return null;

            }
            return new User(username);
        }

        public static SavedUsed? SaveUser(User user)
        {
            Console.WriteLine($"SaveUser: {user.Name}");

            if (user.Name.Contains("B"))
            {
                return null;
            }
            return new SavedUsed(user);
        }

        public static int? SendEmail(SavedUsed user)
        {
            Console.WriteLine($"Sending email: {user.User.Name}");

            if (user.User.Name.Contains("C"))
            {
                return null;
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

