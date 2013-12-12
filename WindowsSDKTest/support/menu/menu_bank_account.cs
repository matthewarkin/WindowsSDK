using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu_bank_account()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Bank Account APIs:");
            Console.WriteLine("  get_bank_account       retrieve a bank_account by ID");
            Console.WriteLine("  get_all_bank_accounts  retrieve all bank accounts");
            Console.WriteLine("  del_bank_account       delete a bank account by ID");
            Console.WriteLine("  create_bank_account    create a bank account");
            Console.WriteLine("===============================================================================");
        }
    }
}
