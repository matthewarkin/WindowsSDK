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
            Console.WriteLine("  ?                 help / this menu");
            Console.WriteLine("  q                 quit / exit this application");
            Console.WriteLine("  config            show email, password, endpoint URL, and token");
            Console.WriteLine("  find_endpoint     find endpoint using configured credentials");
            Console.WriteLine("  authenticate      reconfigure credentials and authenticate");
            Console.WriteLine("");
            Console.WriteLine("Payment APIs:");
            Console.WriteLine("  key_payment       process a simple payment using keyed card details");
            Console.WriteLine("  track1_payment    process a payment containing track1 data");
            Console.WriteLine("  track2_payment    process a payment containing track2 data");
            Console.WriteLine("  refund_payment    process a refund for a specific ID");
            Console.WriteLine("  get_payment       retrieve a payment by ID");
            Console.WriteLine("  get_all_payments  retrieve all payments");
            Console.WriteLine("  search_payments   retrieve all payments within a date range");
            Console.WriteLine("");
            Console.WriteLine("Bank Account APIs:");
            Console.WriteLine("  get_bank_account       retrieve a bank_account by ID");
            Console.WriteLine("  get_all_bank_accounts  retrieve all bank accounts");
            Console.WriteLine("  del_bank_account       delete a bank account by ID");
            Console.WriteLine("  create_bank_account    create a bank account");
            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
        }
    }
}
