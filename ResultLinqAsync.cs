using CSharpFunctionalExtensions;

namespace ConsoleApp
{
    public class ResultLinqAsync
    {

        public record Error(string msg);
        public record ValidationError(string msg) : Error(msg);
        public record SaveUserError(string msg) : Error(msg);
        public record SendEmailError(string msg) : Error(msg);

        public static async Task Run()
        {
            Result<int, Error> a;
            a = await from validUser in ValidateUser("AB")
                      from savedUser in SaveUser(validUser)
                      from emailReturnCode in SendEmail(savedUser)
                      select emailReturnCode;

            if (a.IsSuccess)
            {
                Console.WriteLine($"Success: {a.Value}");
            }
            else
            {
                Console.WriteLine($"Failure: {a.Error.msg}");
            }
        }

        public static async Task<Result<User, Error>> ValidateUser(string username)
        {
            Console.WriteLine($"ValidateUser: {username}");

            if (username.Contains("A"))
            {
                return await Task.FromResult(Result.Failure<User, Error>(new ValidationError($"username includes illegal char")));

            }
            return await Task.FromResult(Result.Success<User, Error>(new User(username)));
        }

        public static async  Task<Result<SavedUsed, Error>> SaveUser(User user)
        {
            Console.WriteLine($"SaveUser: {user.Name}");

            if (user.Name.Contains("B"))
            {
                return await Task.FromResult(Result.Failure<SavedUsed, Error>(new SaveUserError($"SaveUserError")));

            }
            return await Task.FromResult(Result.Success<SavedUsed, Error>(new SavedUsed(user)));
        }

        public static async Task<Result<int, Error>> SendEmail(SavedUsed user)
        {
            Console.WriteLine($"Sending email: {user.User.Name}");

            if (user.User.Name.Contains("C"))
            {
                return await Task.FromResult(Result.Failure<int, Error>(new SendEmailError($"SaveUserError")));

            }
            return await Task.FromResult(Result.Success<int, Error>(1));
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
