using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu_payment()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Payment APIs:");
            Console.WriteLine("  key_payment       process a simple payment using keyed card details");
            Console.WriteLine("  track1_payment    process a payment containing track1 data");
            Console.WriteLine("  track2_payment    process a payment containing track2 data");
            Console.WriteLine("  refund_payment    process a refund for a specific ID");
            Console.WriteLine("  get_payment       retrieve a payment by ID");
            Console.WriteLine("  get_all_payments  retrieve all payments");
            Console.WriteLine("  search_payments   retrieve all payments within a date range");
            Console.WriteLine("===============================================================================");
        }
    }
}
