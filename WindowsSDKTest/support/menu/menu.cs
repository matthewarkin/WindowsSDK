using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("General:");
            Console.WriteLine("  ?                  help / this menu");
            Console.WriteLine("  q                  quit / exit this application");
            Console.WriteLine("  config             show email, password, endpoint URL, and token");
            Console.WriteLine("  find_endpoint      find endpoint using configured credentials");
            Console.WriteLine("  authenticate       reconfigure credentials and authenticate");
            Console.WriteLine("  token detail       retrieve and display token details");
            Console.WriteLine("  ? authorization    show authorization commands");
            Console.WriteLine("  ? payment          show payment commands");
            Console.WriteLine("  ? stored_payment   show stored_payment commands");
            Console.WriteLine("  ? bank_account     show bank_account commands");
            Console.WriteLine("  ? ach              show ach commands");
            Console.WriteLine("  ? report           show report commands");
            Console.WriteLine("===============================================================================");
        }
    }
}
