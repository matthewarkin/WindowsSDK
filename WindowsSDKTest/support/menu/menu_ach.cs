using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu_ach()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("ACH APIs:");
            Console.WriteLine("  ach_balance     retrieve the balance that is available to be sent via ACH.");
            Console.WriteLine("                  same as the available_balance in the account report.");
            Console.WriteLine("  ach_settlement  send funds from your SlidePay account to a bank account");
            Console.WriteLine("                  that you have previously configured (by bank_account_id");
            Console.WriteLine("  ach_retrieval   retrieve funds from bank account into your SlidePay account");
            Console.WriteLine("");
            Console.WriteLine("NOTE: To use ACH settlements, you must be configured for manual settlement.");
            Console.WriteLine("      To use ACH retrievals, you must be approved by api@slidepay.com.");
            Console.WriteLine("===============================================================================");
        }
    }
}
