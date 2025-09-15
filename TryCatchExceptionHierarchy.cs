
namespace ConsoleApp
{
    public class TryCatchExceptionHierarchy
    {
        public class ValidationException(string message) : Exception(message);
        public class SaveUserException(string message) : Exception(message);
        public class SendEmailException(string message) : Exception(message);

        public static void Run()
        {
         
            try
            {
                var validUser = ValidateUser("A");
                var savedUser = SaveUser(validUser);
                var emailReturnValue = SendEmail(savedUser);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SaveUserException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SendEmailException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex) // Catch all
            {
                Console.WriteLine($"Unknown error");
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
