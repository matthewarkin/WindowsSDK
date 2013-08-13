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
            Console.WriteLine("  Email: " + context._email);
            Console.WriteLine("  Password: " + context._password);
            Console.WriteLine("  Endpoint: " + context._endpoint_url);

            if (!string_null_or_empty(context._token_string))
            {
                if (context._token_string.Length > 40)
                {
                    Console.WriteLine("  Token: " + context._token_string.Substring(0, 40) + "...<truncated>");
                }
                else
                {
                    Console.WriteLine("  Token: " + context._token_string);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
        }
    }
}
