using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool create_bank_account(SlidePayWindowsSDK context)
        {
            #region Variables

            string account_company_name = "";
            string account_first_name = "";
            string account_last_name = "";
            string account_address_1 = "";
            string account_city = "";
            string account_state = "";
            string account_postal_code = "";
            string account_phone = "";
            string account_type = "";
            string routing_number = "";
            string account_number = "";
            int is_settlement_account = 0;            
            bank_account resp_bank_account = new bank_account();

            #endregion

            #region Populate-Variables

            Console.WriteLine("Answer the following questions using information found on your check.");
            Console.Write("Company Name (blank for personal account): ");
            account_company_name = Console.ReadLine();

            Console.Write("First Name (blank for company account): ");
            account_first_name = Console.ReadLine();

            Console.Write("Last Name (blank for company account): ");
            account_last_name = Console.ReadLine();

            Console.Write("Address Line 1: ");
            account_address_1 = Console.ReadLine();

            Console.Write("City: ");
            account_city = Console.ReadLine();

            Console.Write("State: ");
            account_state = Console.ReadLine();

            Console.Write("Postal Code: ");
            account_postal_code = Console.ReadLine();

            Console.Write("Phone Number: ");
            account_phone = Console.ReadLine();

            Console.WriteLine("Valid options: Business Checking, Business Savings");
            Console.WriteLine("               Personal Checking, Personal Savings");
            Console.Write("Type of Account: ");
            account_type = Console.ReadLine();

            Console.Write("Routing Number: ");
            routing_number = Console.ReadLine();

            Console.Write("Account Number: ");
            account_number = Console.ReadLine();
 
            Console.Write("Use as Settlement Account?  (1 for yes, 0 for no): ");
            is_settlement_account = Convert.ToInt32(Console.ReadLine());
            
            #endregion

            #region Check-for-Null-or-Bad-Values

            if (string_null_or_empty(account_address_1) ||
                string_null_or_empty(account_city) ||
                string_null_or_empty(account_state) ||
                string_null_or_empty(account_postal_code) ||
                string_null_or_empty(account_phone) ||
                string_null_or_empty(account_type) ||
                string_null_or_empty(routing_number) ||
                string_null_or_empty(account_number))
            {
                Console.WriteLine("Please complete all required fields.");
                return false;
            }
            
            #endregion

            #region Process-Request

            resp_bank_account = context.sp_create_bank_account(
                account_type,
                routing_number,
                account_number,
                account_company_name,
                account_first_name,
                account_last_name,
                account_address_1,
                account_city,
                account_state,
                account_postal_code,
                account_phone,
                is_settlement_account);

            if (resp_bank_account == null)
            {
                Console.WriteLine("Null response for bank_account retrieval request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("bank_account created: " + resp_bank_account.bank_account_id);
            Console.WriteLine("  type " + resp_bank_account.type + " routing " + resp_bank_account.routing_number + " account " + resp_bank_account.account_number);
            Console.WriteLine("  is_settlement_account " + resp_bank_account.is_settlement_account + " is_verified " + resp_bank_account.is_verified);
            Console.WriteLine("===============================================================================");
            
            #endregion

            return true;
        }
    }
}
