using System;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void exit_application(string message)
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.WriteLine("Please review the debug output for more details.");
            Console.WriteLine("The application is exiting.  Press ENTER to exit.");
            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.ReadLine();
            Environment.Exit(-1);
        }
    }
}