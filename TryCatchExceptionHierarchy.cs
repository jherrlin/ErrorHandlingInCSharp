using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TryCatchExceptionHierarchy
    {
        public class ValidationException(string message) : Exception(message);
        public class SaveUserException(string message) : Exception(message);
        public class SendEmailException(string message) : Exception(message);

        public static async Task Run()
        {
         
            try
            {
                var validUser = await ValidateUser("A");
                var savedUser = await SaveUser(validUser);
                var emailReturnValue = await SendEmail(savedUser);
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

        public static async Task<User> ValidateUser(string username)
        {
            Console.WriteLine($"ValidateUser: {username}");

            if (username.Contains("A"))
            {
                throw new Exception("username includes illegal char");

            }
            return new User(username);
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
