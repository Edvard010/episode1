using System;
using System.Collections.Generic;
using System.Text;

namespace episode1.Models
{
    class Exceptions
    {
        public void Test()
        {
            try
            {
                User user = new User("user@email.com", "Secret");
                user = null;
                throw new ArgumentNullException(nameof(user));
                // sing up user
                //email in use
                throw new Exception("Email in use.");
            }
            catch(ArgumentNullException exception)
            {
                Console.WriteLine($"Null error: {exception}");
            }
            catch(Exception exception)
            {
                Console.WriteLine($"An error: {exception}");
            }
            finally
            {
                Console.WriteLine("Dispose");
                //Dispose();
            }
            Console.WriteLine("OK");
        }
    }
}
