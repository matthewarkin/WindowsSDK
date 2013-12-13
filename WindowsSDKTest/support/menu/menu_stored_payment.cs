using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu_stored_payment()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Stored Payment APIs:");
            Console.WriteLine("  create_stored_payment    create a stored payment object (charge card by GUID)");
            Console.WriteLine("  get_stored_payment       retrieve a specific stored payment object by GUID");
            Console.WriteLine("  get_all_stored_payments  retrieve all stored payment objects");
            Console.WriteLine("  delete_stored_payment    delete a stored payment object");
            Console.WriteLine("===============================================================================");
        }
    }
}
