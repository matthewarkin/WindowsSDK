using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void display_config(SlidePayWindowsSDK context)
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("");
            Console.WriteLine("Current configuration:");
            Console.WriteLine("  Email: " + slidepay._email);
            Console.WriteLine("  Password: " + slidepay._password);
            Console.WriteLine("  Endpoint: " + slidepay._endpoint_url);

            if (!string_null_or_empty(slidepay._token_string))
            {
                if (slidepay._token_string.Length > 40)
                {
                    Console.WriteLine("  Token: " + slidepay._token_string.Substring(0, 40) + "...<truncated>");
                }
                else
                {
                    Console.WriteLine("  Token: " + slidepay._token_string);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
        }
    }
}
