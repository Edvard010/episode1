using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace episode1.Models
{
    public class Reflections
    {
        public void Test()
        {
            var user = new User("user1@email.com", "secret");
            var type = user.GetType().GetTypeInfo();
            Console.WriteLine($"{type.Name} {type.Namespace} {type.FullName}");
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                //Console.WriteLine($"{method.Name}");
            }
            user.Activate();
            Console.WriteLine($"Is active: {user.IsActive}.");
            var deactivateMethod = methods.First(x => x.Name == "DeActivate");
            deactivateMethod.Invoke(user, null);
            Console.WriteLine($"Is active: {user.IsActive}.");
            Console.WriteLine($"Email: {user.Email}.");
            var setEmailMethod = type.GetMethod("SetEmail");
            setEmailMethod.Invoke(user, new[] { "user2@email.com" });
            Console.WriteLine($"Email: {user.Email}");
            var email = type.GetProperty("Email").GetValue(user);
            Console.WriteLine($"Email: {email}");

            var databaseTypes = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(x => x.Name.Contains("DataBase"));
            foreach (var databaseType in databaseTypes)
            {
                Console.WriteLine($"{databaseType}");
            }

            var user3 = (User)Activator.CreateInstance(typeof(User), new[] { "user3@email.com", "secret" });
            Console.WriteLine($"{user3.Email}");
        }

    }
    public class Dynamics
    {
        public void Test()
        {
            dynamic user = new User("user1@email.com", "secret");
            Console.WriteLine($"{user.Email}");
            user.SetEmail("user2@gmail.com");
            Console.WriteLine($"{user.Email}");

            dynamic anything = new ExpandoObject();
            anything.id = 1;
            anything.name = "me";
            Console.WriteLine($"{anything.id} {anything.name}");
            foreach (var property in anything)
            {
                Console.WriteLine($"{property.Key}: {property.Value}");
            }
        }
    }
    public class Attributes
    {
        public void Test()
        {
            var user = new User("user1@email.com", "secret");
            var passwordAttribute = (UserPasswordAttribute)user.GetType()
                .GetTypeInfo()
                .GetProperty("Password")
                .GetCustomAttribute(typeof(UserPasswordAttribute));

            var isPasswordValid = user.Password.Length == passwordAttribute.Length;
            Console.WriteLine($"Is valid: {isPasswordValid}.");
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class UserPasswordAttribute : Attribute
    {
        public int Length { get; }
        public UserPasswordAttribute(int length = 4)
        {
            Length = length;
        }
    }
    public class Asynchronous
    {
        public async Task Test()
        {
            var content = await GetContentAsync();
            Console.WriteLine(content);
        }
        public async Task<string> GetContentAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
    public class Paralellism
    {
        public void Test()
        {
            var numbers = Enumerable.Range(1, 100);
            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine($"Number {number} on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            });
        }
    }
}
