using CSharpFunctionalExtensions;


namespace ConsoleApp
{
    public class ResultString
    {
        public static void Run()
        {
            //     TSuccess, TError 
            Result<int     ,string> a = ValidateUser("A")
                .Bind(SaveUser)
                .Bind(SendEmail);

            if (a.IsSuccess)
            {
                Console.WriteLine($"Success: {a.Value}");
            }
            else
            {
                Console.WriteLine($"Failure: {a.Error}");
            }
        }

        public static Result<User, string> ValidateUser(string username)
        {
            Console.WriteLine($"ValidateUser: {username}");

            if (username.Contains("A"))
            {
                return Result.Failure<User, string>($"username includes illegal char");

            }
            return Result.Success<User, string>(new User(username));
        }

        public static Result<SavedUsed, string> SaveUser(User user)
        {
            Console.WriteLine($"SaveUser: {user.Name}");

            if (user.Name.Contains("B"))
            {
                return Result.Failure<SavedUsed, string>($"SaveUserError");

            }
            return Result.Success<SavedUsed, string>(new SavedUsed(user));
        }

        public static Result<int, string> SendEmail(SavedUsed user)
        {
            Console.WriteLine($"Sending email: {user.User.Name}");

            if (user.User.Name.Contains("C"))
            {
                return Result.Failure<int, string>($"SaveUserError");

            }
            return Result.Success<int, string>(1);
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
