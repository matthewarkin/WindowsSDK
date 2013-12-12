using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu_report()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Report APIs:");
            Console.WriteLine("  payment_report  retrieve a payment report based on location ID, date range");
            Console.WriteLine("  account_report  retrieve an account report based on location ID, date range");
            Console.WriteLine("===============================================================================");
        }
    }
}
