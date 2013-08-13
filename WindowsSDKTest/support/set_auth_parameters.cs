using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void set_auth_parameters(out string email, out string password, out string proxy_url)
        {
            while (true)
            {
                Console.Write("Email address: ");
                email = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();

                if (!string_null_or_empty(email) && !string_null_or_empty(password))
                {
                    break;
                }

                Console.WriteLine("");
                Console.WriteLine("Please supply an email address and a password.");
                Console.WriteLine("");
            }

            Console.Write("Proxy URL (example: http://127.0.0.1:8888, ENTER for none): ");
            proxy_url = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Authentication parameters set.");
        }
    }
}
