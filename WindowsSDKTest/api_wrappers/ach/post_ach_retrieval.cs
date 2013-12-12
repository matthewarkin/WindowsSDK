using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool post_ach_retrieval(SlidePayWindowsSDK context)
        {
            #region Variables

            int company_id = 0;
            int location_id = 0;
            int user_master_id = 0;
            int? bank_account_id = 0;
            string bank_account_type = "";
            string bank_account_routing_number = "";
            string bank_account_account_number = "";
            string bank_account_company_name = "";
            string bank_account_first_name = "";
            string bank_account_last_name = "";
            string bank_account_address_1 = "";
            string bank_account_address_2 = "";
            string bank_account_city = "";
            string bank_account_state = "";
            string bank_account_postal_code = "";
            string bank_account_country = "";
            string bank_account_phone_country_code = "";
            string bank_account_phone = "";
            decimal retrieval_amount = 0m;
            string notes = "";

            processor_ach_txn_response ret = new processor_ach_txn_response();
            
            #endregion

            #region Populate-Variables
            
            Console.Write("Company ID: ");
            try
            {
                company_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert company ID from string to integer.");
                return false;
            }
            
            Console.Write("Location ID: ");
            try
            {
                location_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert location ID from string to integer.");
                return false;
            }

            Console.Write("User Master ID: ");
            try
            {
                user_master_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert user master ID from string to integer.");
                return false;
            }

            Console.Write("Bank Account ID (use 0 if not using bank_account_id): ");
            try
            {
                bank_account_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert bank account ID from string to integer.");
                return false;
            }

            Console.Write("Bank Account Type [Personal||Business Checking||Savings]: ");
            bank_account_type = Console.ReadLine();

            Console.Write("Routing Number: ");
            bank_account_routing_number = Console.ReadLine();

            Console.Write("Account Number: ");
            bank_account_account_number = Console.ReadLine();

            Console.Write("Company Name (null for personal account): ");
            bank_account_company_name = Console.ReadLine();

            Console.Write("First Name (null for business account): ");
            bank_account_first_name = Console.ReadLine();
            
            Console.Write("Last Name (null for business account): ");
            bank_account_last_name = Console.ReadLine();
            
            Console.Write("Address 1: ");
            bank_account_address_1 = Console.ReadLine();
            
            Console.Write("Address 2: ");
            bank_account_address_2 = Console.ReadLine();
            
            Console.Write("City: ");
            bank_account_city = Console.ReadLine();
            
            Console.Write("State: ");
            bank_account_state = Console.ReadLine();
            
            Console.Write("Postal Code: ");
            bank_account_postal_code = Console.ReadLine();
            
            Console.Write("Country: ");
            bank_account_country = Console.ReadLine();
            
            Console.Write("Phone Country Code (1 for USA): ");
            bank_account_phone_country_code = Console.ReadLine();
            
            Console.Write("Phone: ");
            bank_account_phone = Console.ReadLine();
            
            Console.Write("Retrieval Amount: ");
            try
            {
                retrieval_amount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert retrieval amount from string to integer.");
                return false;
            }

            Console.Write("Notes: ");
            notes = Console.ReadLine();

            #endregion

            #region Process-Request

            ret = context.sp_ach_retrieval(
                    company_id,
                    location_id,
                    user_master_id,
                    bank_account_id,
                    bank_account_type,
                    bank_account_routing_number,
                    bank_account_account_number,
                    bank_account_company_name,  
                    bank_account_first_name,  
                    bank_account_last_name,  
                    bank_account_address_1,
                    bank_account_address_2,  
                    bank_account_city,
                    bank_account_state,
                    bank_account_postal_code,
                    bank_account_country,
                    bank_account_phone_country_code,
                    bank_account_phone,
                    retrieval_amount,
                    notes);

            if (ret == null)
            {
                Console.WriteLine("Null response for ach retrieval request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("sp_ach_retrieval:");
            Console.WriteLine("  ID: amount / routing / account");
            Console.WriteLine("      status / transaction_token");
            Console.WriteLine("  " + ret.settlement_id + ": " + ret.amount + " / " + ret.routing_number + " / " + ret.account_number);
            Console.WriteLine("      " + ret.provider_status + " / " + ret.settlement_transaction_token);        
            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
